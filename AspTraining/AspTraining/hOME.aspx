<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hOME.aspx.cs" Inherits="AspTraining.hOME" ErrorPage="~/error.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Here are some cities:
            <ul>
                <asp:Repeater ItemType="System.String" SelectMethod="GetCity" runat="server">
                    <ItemTemplate>
                        <li><%# Item %> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <asp:TextBox id="TextBox1" runat="server" value="1"/>
            <asp:TextBox id="TextBox2" runat="server" value="2"/>
            <asp:Button onclick="<%= err() %>"  Text ="Click" runat="server" >  </asp:Button>
        </div>
        <span id="abc" ></span>
    </form>
</body>
</html>
