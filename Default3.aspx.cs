using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string text = File.ReadAllText(@"d:\JSONNT.txt", Encoding.UTF8);
        WebClient c = new WebClient();       
        JObject o = JObject.Parse(text);
        
        Response.Write("Name: " + o["name"].ToString());
        Response.Write("<br/>");

        Response.Write("Email Address[1]: " + o["email"][0]);
        Response.Write("<br/>");

        Response.Write("Email Address[2]: " + o["email"][1]);
        Response.Write("<br/>");

        Response.Write("Website [home page]: " + o["websites"]["home page"]);
        Response.Write("<br/>");

        Response.Write("Website [blog]: " + o["websites"]["blog"]);
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string text = File.ReadAllText(@"d:\Json04032016.txt", Encoding.UTF8);
        WebClient c = new WebClient();
        JObject o = JObject.Parse(text);

        Response.Write("Type: " + o["Type"].ToString());
        Response.Write("<br/><br/>");

        Response.Write("MessageId: " + o["MessageId"].ToString());
        Response.Write("<br/><br/>");

        Response.Write("TopicArn: " + o["TopicArn"].ToString());
        Response.Write("<br/><br/>");

        Response.Write("Message " + o["Message"].ToString());
        Response.Write("<br/><br/>");


       string notType = o["Message"].ToString();
        JObject n = JObject.Parse(notType);

        Response.Write("notificationType: " + n["notificationType"].ToString());
        Response.Write("<br/><br/>");

        Response.Write("complaint " + n["complaint"].ToString());
        Response.Write("<br/><br/>");

        string compRecip = n["complaint"]["complainedRecipients"].ToString();
       // JObject cr = JObject.Parse(compRecip);

        //Response.Write("complainedRecipients: " + cr["emailAddress"]);


        Response.Write("complainedRecipients: " + compRecip);
        Response.Write("<br/><br/>");
        Response.Write("complaintFeedbackType:" + n["complaint"]["complaintFeedbackType"]);
        Response.Write("<br/><br/>");
        Response.Write("Source:" + n["mail"]["source"]);

        Response.Write("<br/><br/>");
        Response.Write("Destination:" + n["mail"]["destination"]);


       // string compRecip = n["complaint"].ToString();
        //JObject cr = JObject.Parse(compRecip);

        //Response.Write("notificationType: " + n["notificationType"].ToString());
        //Response.Write("<br/><br/>");

        //Response.Write("complaint " + n["complaint"].ToString());
        //Response.Write("<br/><br/>");









        //Response.Write("Website [blog]: " + o["websites"]["blog"]);

        
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        ParseJsonMsg();


    }
    public void ParseJsonMsg()
    {
        string text = File.ReadAllText(@"d:\Json04032016.txt", Encoding.UTF8);
       // WebClient c = new WebClient();
        JObject o = JObject.Parse(text);

        string notMsg = o["Message"].ToString();
        JObject n = JObject.Parse(notMsg);

        string notType = n["notificationType"].ToString();
        Response.Write(notType);
        Response.Write("<br/><br/>");

        string compFeedBack;
        if (notMsg.Contains("complaintFeedbackType"))
        {
             compFeedBack = n["complaint"]["complaintFeedbackType"].ToString();
        }
        else
        {
            compFeedBack = "NoType";
        }
         //compFeedBack = n["complaint"]["complaintFeedbackType"].ToString();
        Response.Write(compFeedBack);
        Response.Write("<br/><br/>");

        string mailSource = n["mail"]["source"].ToString();
        Response.Write(mailSource);
        Response.Write("<br/><br/>");

        string mailDest = n["mail"]["destination"].ToString();

        mailDest = mailDest.Substring(2, mailDest.Length - 3).Replace("\"", "");
        Response.Write(mailDest);
        Response.Write("<br/><br/>");
    }

}