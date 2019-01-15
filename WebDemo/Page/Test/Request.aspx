<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="Page.Request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Test/Response.aspx?username=DLz&password=123456">.......</a>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <a href ="Test/Response.aspx"></a>
        </div>
    </form>
</body>
</html>
