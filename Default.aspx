﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" /><br />
    <asp:Button ID="Button2" runat="server" Text="Insert" onclick="Button2_Click" /><br />
    <asp:Button ID="Button3" runat="server" Text="Update" onclick="Button3_Click" /><br />
     <asp:Button ID="Button4" runat="server" Text="Delete" 
        onclick="Button4_Click"  /><br />

    </form>
</body>
</html>