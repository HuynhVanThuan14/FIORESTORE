<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCategory.ascx.cs" Inherits="FioreStore.admin.News.NewsCategory" %>
<div>DANH SÁCH TIN TỨC</div>
<asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">
        <asp:View ID="v1" runat="server">
            <div>
                <asp:Repeater ID="rptNewsCategory" runat="server" OnItemCommand="rptNewsCategory_ItemCommand">
                    <HeaderTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="width:300px;">Catagory Name</td>
                                <td style="width:50px;">Order</td>
                                <td style="width:100px;">Active</td>
                                <td></td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr>
                                <td><asp:LinkButton ID="InkUpdate" runat="server" CommandName="update" CommandArgument='<%#: Eval("CateID")%>'><%#: Eval("Name") %></asp:LinkButton></td>
                                <td><%#: Eval("Order") %></td>
                                <td><%#: Eval("Active") %></td>
                                <td><asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#: Eval("CateID")%>' OnLoad="Delete_Load">Xoá</asp:LinkButton></td>

                            </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lnkAddNew_Click">Add</asp:LinkButton>
        </asp:View>

        <asp:View ID="v2" runat="server">
            <asp:HiddenField ID="hdCategoryID" runat="server"/>
            <asp:HiddenField ID="hdInsert" runat="server"/>

            <table>
                <tr>
                    <td>Category Name</td>
                    <td><asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Order</td>
                    <td><asp:TextBox ID="txtOrder" runat="server"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Active</td>
                    <td><asp:Checkbox ID="chkActive" runat="server" Checked="true"></asp:Checkbox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnSave" runat="server" Text="Cập nhật" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
        </asp:View>


</asp:MultiView>

