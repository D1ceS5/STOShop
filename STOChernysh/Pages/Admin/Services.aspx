<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="STOChernysh.Pages.Admin.Services" MasterPageFile="~/Pages/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListView1"
        ItemType="STOChernysh.Models.Service"
        SelectMethod="GetServices"
        DataKeyNames="ServiceId"
        UpdateMethod="UpdateService"
        DeleteMethod="DeleteService"
        InsertMethod="InsertService"
        InsertItemPosition="LastItem"
        EnableViewState="false"
        runat="server">
        <LayoutTemplate>
            <div>
                <table id="ordersTable">
                    <tr>
                        <th>Имя заказа</th>
                        <th>Описание</th>
                        <th>Категория</th>
                        <th>Цена</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Name %></td>
                <td class="description"><span><%#Item.Description %></span></td>
                <td><%# GetCategory(Item.Categories_CategoryId) %></td>
                <td><%# Item.Price.ToString("C") %></td>
                <td>
                    <asp:Button ID="Button1" CommandName="Edit" Text="Изменить" runat="server" />
                    <asp:Button ID="Button2" CommandName="Delete" Text="Удалить" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <input name="name" value="<%# Item.Name %>" />
                    <input type="hidden" name="ProductID" value="<%# Item.ServiceId %>" />
                </td>
                <td>
                    <input name="description" value="<%# Item.Description %>" />
                </td>
                <td>
                    <input name="category" value="<%#  GetCategory(Item.Categories_CategoryId) %>" />
                </td>
                <td>
                    <input name="price" value="<%# Item.Price %>" />
                </td>
                <td>
                    <asp:Button ID="Button3" CommandName="Update" Text="Обновить" runat="server"/>
                    <asp:Button ID="Button4" CommandName="Cancel" Text="Отмена" runat="server"/>
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <input name="name" />
                    <input type="hidden" name="ProductID" value="0"/>
                </td>
                <td>
                    <input name="description" />
                </td>
                <td>
                    <input name="categories_categoryId" />
                </td>
                <td>
                    <input name="price" />
                </td>
                
                <td>

                    <asp:Button ID="Button5" CommandName="Insert" Text="Вставить" runat="server" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

</asp:Content>

