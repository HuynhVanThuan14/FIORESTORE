<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FioreStore.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 500px">
        <asp:Repeater ID="rptProductCart" runat="server">
            <HeaderTemplate>
                <table id="product-cart" style="width: 80%; margin: 50px auto;">
                    <tr>
                        <th>Tên sản phẩm</th>
                        <th>Số lượng</th>
                        <th>Giá</th>
                        <th>Thành tiền</th>
                        <th></th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Eval("Name") %></td>
                    <td><%#: Eval("Quantity") %></td>
                    <td><%#:string.Format("{0:N0}",Eval("Price")) %></td>
                    <td><%#:string.Format("{0:N0}",Eval("Money")) %></td>
                    <td>
                        <asp:LinkButton ID="lnkDelete" runat="server">Xoá</asp:LinkButton></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <div style="color: red; text-align: right; font-weight: 600; margin-right: 160px;">
            Tổng thành tiền: <asp:Literal ID="ltTotal" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
