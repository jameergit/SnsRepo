using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Extensions;
using System.Web.Script.Serialization;
using System.Collections;
using System.IO;
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    string text = "";

    protected void Page_Load(object sender, EventArgs e)
    {
         text = File.ReadAllText(@"d:\JSON.txt", Encoding.UTF8);
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
               if (text.Length > 0)
        {
            //tbOutput.Clear();
            ParseJSONString(text);
        }

    }
    int indentLevel = 0;
    private bool ParseJSONString(string input)
    {
        bool bSuccess = false;
        JavaScriptSerializer ser = new JavaScriptSerializer();
        Dictionary<string, object> dict = ser.Deserialize<Dictionary<string, object>>(input);



        bSuccess = DisplayDictionary(dict);


        return true;
    }
    private bool DisplayDictionary(Dictionary<string, object> dict)
    {
        bool bSuccess = false;
        indentLevel++;

        foreach (string strKey in dict.Keys)
        {
            string strOutput = "".PadLeft(indentLevel * 8) + strKey + ":";
           //tbOutput.AppendText("\r\n" + strOutput);
            Response.Write("\r\n" + strOutput);

            object o = dict[strKey];
            if (o is Dictionary<string, object>)
            {
                DisplayDictionary((Dictionary<string, object>)o);
            }
            else if (o is ArrayList)
            {
                foreach (object oChild in ((ArrayList)o))
                {
                    if (oChild is string)
                    {
                        strOutput = ((string)oChild);
                        //tbOutput.AppendText(strOutput + ",");
                        Response.Write(strOutput + ",");
                    }
                    else if (oChild is Dictionary<string, object>)
                    {
                        DisplayDictionary((Dictionary<string, object>)oChild);
                       // tbOutput.AppendText("\r\n");
                        Response.Write("\r\n");
                    }
                }
            }
            else if (strKey=="Message")
            {
                bool bSuccess1 = false;
                string Message = dict["Message"].ToString();


              
                JavaScriptSerializer ser1 = new JavaScriptSerializer();
                Dictionary<string, object> dict1 = ser1.Deserialize<Dictionary<string, object>>(Message);
                if(Convert.ToString(dict1["notificationType"])=="Complaint")
                {
                    string value = dict1["complaint"].ToString();
                   // JavaScriptSerializer ser = new JavaScriptSerializer();
                    //Dictionary<string, object> dict1 = ser.Deserialize<Dictionary<string, object>>(Message);
               

                }


               // strOutput = o.ToString();
                //tbOutput.AppendText(strOutput);
                //Response.Write(strOutput);
            }
        }

        indentLevel--;

        return bSuccess;
    }
}