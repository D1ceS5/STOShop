<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" Inherits="STOChernysh.Controls.CartSummary" %>
<div id="cartSummary">
    <span class="caption">
        <b>В корзине</b>
        <span id="csQuantity" runat="server">товаров, </span>
        <span> на </span>
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Корзина</a>
</div>