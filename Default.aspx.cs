using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sfdc1;

public partial class _Default : System.Web.UI.Page 
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        
string userName;

string password;
userName = "jameer@utkata.com";
password = "Aiza@123j4hOTZNNJlotUcQx6ztbsOvDL";
SforceService SfdcBinding = new SforceService();    
LoginResult CurrentLoginResult = null;


try {

   CurrentLoginResult = SfdcBinding.login(userName, password);

}

catch (System.Web.Services.Protocols.SoapException ex) {

   // This is likley to be caused by bad username or password

   SfdcBinding = null;

   throw (ex);

}

catch (Exception ee) {

   // This is something else, probably comminication

   SfdcBinding = null;

   throw (ee);

}

        
//Change the binding to the new endpoint

SfdcBinding.Url = CurrentLoginResult.serverUrl;

//Create a new session header object and set the session id to that returned by the login

SfdcBinding.SessionHeaderValue = new SessionHeader();
SfdcBinding.SessionHeaderValue.sessionId = CurrentLoginResult.sessionId;

QueryResult queryResult = null;
String SOQL = "";

SOQL = "select fname__c from Jam__c where email__c = 'e'";
queryResult = SfdcBinding.query(SOQL);

        if (queryResult.size > 0) {

  //put some code in here to handle the records being returned

  int i = 0;

  Jam__c fn = (Jam__c)queryResult.records[i];

  string firstName = fn.fname__c;

  //string lastName = lead.LastName;

  //string businessPhone = lead.Phone;
  TextBox1.Text = firstName;

} else {

  //put some code in here to handle no records being returned

  //string message = "No records returned.";
  TextBox1.Text = "No Data";

}

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Jam__c insertProduct = new Jam__c();
        //insertProduct.IsActive = true;
       // insertProduct.IsActiveSpecified = true;
        insertProduct.fname__c = "eeee";
        insertProduct.email__c = "e";

        Response.Write("Name:" + insertProduct.fname__c);
        Response.Write("<br/>ProductCode:" + insertProduct.email__c);

        string userName;

        string password;
        userName = "jameer@utkata.com";
        password = "Aiza@123j4hOTZNNJlotUcQx6ztbsOvDL";
        SforceService SfdcBinding = new SforceService();
        LoginResult CurrentLoginResult = null;


        try
        {

            CurrentLoginResult = SfdcBinding.login(userName, password);

        }

        catch (System.Web.Services.Protocols.SoapException ex)
        {

            // This is likley to be caused by bad username or password

            SfdcBinding = null;

            throw (ex);

        }

        catch (Exception ee)
        {

            // This is something else, probably comminication

            SfdcBinding = null;

            throw (ee);

        }


        //Change the binding to the new endpoint

        SfdcBinding.Url = CurrentLoginResult.serverUrl;

        //Create a new session header object and set the session id to that returned by the login

        SfdcBinding.SessionHeaderValue = new SessionHeader();
        SfdcBinding.SessionHeaderValue.sessionId = CurrentLoginResult.sessionId;

        SaveResult[] createResults = SfdcBinding.create(new sObject[] { insertProduct });

        if (createResults[0].success)
        {
            string id = createResults[0].id;
            Response.Write("<br/>ID:" + id);
            Response.Write("<br/>INSERT Product Successfully!!!");
        }
        else
        {
            string result = createResults[0].errors[0].message;
            Response.Write("<br/>ERROR:" + result);
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Jam__c updateProduct = new Jam__c();
        updateProduct.email__c = "e";
        updateProduct.fname__c = "elephant";

        string userName;

        string password;
        userName = "jameer@utkata.com";
        password = "Aiza@123j4hOTZNNJlotUcQx6ztbsOvDL";
        SforceService SfdcBinding = new SforceService();
        LoginResult CurrentLoginResult = null;


        try
        {

            CurrentLoginResult = SfdcBinding.login(userName, password);

        }

        catch (System.Web.Services.Protocols.SoapException ex)
        {

            // This is likley to be caused by bad username or password

            SfdcBinding = null;

            throw (ex);

        }

        catch (Exception ee)
        {

            // This is something else, probably comminication

            SfdcBinding = null;

            throw (ee);

        }


        //Change the binding to the new endpoint

        SfdcBinding.Url = CurrentLoginResult.serverUrl;

        //Create a new session header object and set the session id to that returned by the login

        SfdcBinding.SessionHeaderValue = new SessionHeader();
        SfdcBinding.SessionHeaderValue.sessionId = CurrentLoginResult.sessionId;


        SaveResult[] updatedResults = SfdcBinding.update(new sObject[] { updateProduct });

        if (updatedResults[0].success)
        {
            string id = updatedResults[0].id;
            Response.Write("<br/>ID:" + id);
            Response.Write("Name:<br/>" + updateProduct.fname__c);
            Response.Write("<br/>UPDATE Product Successfully!!!");
        }
        else
        {
            string result = updatedResults[0].errors[0].message;
            Response.Write("<br/>ERROR:" + result);
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //DeleteResult[] deleteResults = sfdcBinding.delete(new string[] { productid });

        //if (deleteResults[0].success)
        //{
        //    string id = deleteResults[0].id;
        //    Response.Write("<br/>ID:" + id);
        //    Response.Write("<br/>DELETE Product Successfully!!!");
        //}
        //else
        //{
        //    string result = deleteResults[0].errors[0].message;
        //    Response.Write("<br/>ERROR:" + result);
        //}
    }
}