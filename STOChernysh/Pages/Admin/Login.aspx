<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="STOChernysh.Pages.Admin.Login" MasterPageFile="~/Pages/Admin/Login.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" CssClass="error" />
    <div class="loginContainer">
        <div>
            <label for="name">Имя:</label>
            <input name="name" id="name" runat="server" />
        </div>
        <div>
            <label for="password">Пароль:</label>
            <input type="password" name="password" id="password" runat="server" />
        </div>
          <div>
            <label for="passwordcnf">Подтвердите пароль:</label>
            <input  type="password" id="passworcnf" name="passworcnf" runat="server" />
        </div>

        <button type="submit" name="login" id="login" value="1" runat="server" >Войти</button>
        <button type="submit" name="register" id="register"  value="2" runat="server" >Регистрация</button>
        <button type="submit" name="confirm" id="confirm"  value="3" runat="server" >Подтверждение</button>
    </div>
</asp:Content>