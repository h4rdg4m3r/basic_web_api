<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adam.aspx.cs" Inherits="Kidzinski.Adam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Adam.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
</head>
<body style="height: 489px">
    <form id="form1" runat="server">
        <div class="central">
            <div style="height: 55px; width: 392px; text-align: right;" class="auto-style2">
                <asp:Label ID="Username_label" runat="server" Text="Zalogowany użytkownik:" CssClass="opisy"></asp:Label>
    &nbsp;&nbsp;<asp:TextBox ID="Username" runat="server" CssClass="input input2" ToolTip="For example: Jan Kowalski" OnTextChanged="Username_TextChange" AutoPostBack="true"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Error_username" runat="server" ControlToValidate="Username" ErrorMessage="Wprowadzony identyfikator nie jest zgodny ze wzorcem" ValidationExpression="^[A-Z]{1}[a-z,ł]{2,}.[A-Z,Ł]{1}[a-z,ń,ł]{2,}$" Display="Static" ValidationGroup="grupa">*</asp:RegularExpressionValidator>
                <br />
                <br />
                <div style="height: 81px; text-align: center" class="auto-style2">
                    <asp:Label ID="Data_label" runat="server" Text="Okno danych" CssClass="tytul"></asp:Label>
                    <br />
                    <br class="auto-style2" />
                    <div class="auto-style1">
                        <asp:Label ID="Birthday_label" runat="server" Text="Data urodzenia:" CssClass="opisy"></asp:Label>
    &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="Birthday" runat="server" CssClass="input" Enabled="False" Format="dd-MM-yyyy" AutoPostBack="true"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="Error_birthday" runat="server" ControlToValidate="Birthday" ErrorMessage="Zły format daty!" ValidationExpression="^(0[1-9]|[12]\d|3[01])[-](0[1-9]|1[0-2])[-](19|20)\d{2}$" ValidationGroup="grupa">*</asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="Error_birthday_value" runat="server" OnServerValidate="Date_value_textchange" ValidationGroup="grupa" Display="Dynamic">*</asp:CustomValidator>
                    </div>
                    <div style="width: 394px; height: 175px" class="auto-style2">
                        <br />
                        <asp:Label ID="Address_label" runat="server" Text="Adres zamieszkania" CssClass="tytul"></asp:Label>
                        <div class="auto-style1" style="height: 136px; margin-top: 0px">
                            <br />
                            <asp:Label ID="Street_label" runat="server" Text="Nazwa ulicy:" CssClass="opisy"></asp:Label>
    &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="Street" runat="server" CssClass="input" Enabled="False" OnTextChanged="Street_TextChange" AutoPostBack="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Error_street" runat="server" ControlToValidate="Street" ErrorMessage="Format nazwy ulicy niezgodny ze wzorcem" ValidationGroup="grupa" ValidationExpression="^([A-Z,Ś,Ż,Ź,Ł][a-z,ń,ś,ź,ż,ł,ó,ę,ą]{2,}[ ]?)+">*</asp:RegularExpressionValidator>
                            <br />
                            <asp:Label ID="House_label" runat="server" Text="Numer domu / mieszkania:" CssClass="opisy"></asp:Label>
    &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="House" runat="server" CssClass="input" Enabled="False" OnTextChanged="House_TextChange" AutoPostBack="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Error_house" runat="server" ControlToValidate="House" ErrorMessage="Format numeru domu niezgodny ze wzorcem" ValidationGroup="grupa" ValidationExpression="^[0-9]+[A-Z]*(\/[1-9][0-9]*)?">*</asp:RegularExpressionValidator>
                            <br />
                            <asp:Label ID="City_label" runat="server" Text="Miasto:" CssClass="opisy"></asp:Label>
    &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="City" runat="server" CssClass="input" Enabled="False" OnTextChanged="City_TextChange" AutoPostBack="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Error_city" runat="server" ControlToValidate="City" ErrorMessage="Format nazwy miasta niezgodny ze wzorcem" ValidationGroup="grupa" ValidationExpression="^([A-Z,Ś,Ż,Ź,Ł][a-z,ń,ś,ź,ż,ł,ó,ę,ą]{2,}[ ]?)+">*</asp:RegularExpressionValidator>
                            <br />
                            <asp:Label ID="Postal_label" runat="server" Text="Kod pocztowy:" CssClass="opisy"></asp:Label>
    &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="Postal" runat="server" CssClass="input" Enabled="False" OnTextChanged="Postal_TextChange" AutoPostBack="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Error_postal" runat="server" ControlToValidate="Postal" ErrorMessage="Format kodu pocztowego niezgodny ze wzorcem" ValidationGroup="grupa" ValidationExpression="[0-9]{2}-[0-9]{3}">*</asp:RegularExpressionValidator>
                            <br />
                            <br />
                            <div class="auto-style2" style="height: 150px">
                                <asp:ValidationSummary ID="Error_message" runat="server" DisplayMode="List" ValidationGroup="grupa" ShowSummary="true" ShowMessageBox="True" />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
