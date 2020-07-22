<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="STOChernysh.Pages.Default" MasterPageFile="~/Pages/StoreMaster.Master" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server" > 
    <div id="content">
        <div class="item">
                 <% Response.Write(GetBanner()); %>
        <asp:Repeater ItemType="STOChernysh.Models.Service"  SelectMethod="GetServices" runat="server" >
            <ItemTemplate>
                <div class="item">
                  <h3><%# Item.Name %></h3>
                  <%# Item.Description %>
                  <h4> <%# Item.Price.ToString("c") %></h4>
                  <button name="add" type="submit" value="<%# Item.ServiceId %>">
                      В корзину
                  </button>
              </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>