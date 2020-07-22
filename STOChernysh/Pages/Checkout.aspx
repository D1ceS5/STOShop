<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="STOChernysh.Pages.Checkout"  MasterPageFile="~/Pages/StoreMaster.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Оформить заказ</h2>
            Подтвердите данные ниже
       
        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display: none;"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
            <h3>Заказчик</h3>
            <div>
                <label for="name">Имя:</label>
                <SX:VInput Property="Name" runat="server" />
            </div>
            <div>
                <label for="line1">Адресс 1:</label>
                <SX:VInput Property="Line1" runat="server" />
            </div>
           
            <div>
                <label for="city">Город:</label>
                <SX:VInput Property="City" runat="server" />
            </div>

             <div>
                <label for="mail">E-Mail:</label>
                <input type="text" id="mail" name="mail" runat="server" />
            </div>
        <p class="actionButtons">
            <button class="actionButtons" type="submit">Обработать заказ</button>
        </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Спасибо за доверие!</h2>
        </div>
    </div>
</asp:Content>
