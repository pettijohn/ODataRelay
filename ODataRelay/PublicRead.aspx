<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicRead.aspx.cs" Inherits="ODataRelay.PublicRead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="customers"></asp:GridView>
    </div>
    <div>
        <asp:Button ID="myButton" runat="server" Text="Click Me to Insert" OnClick="myButton_Click" />
    </div>
    </form>
</body>
</html>
