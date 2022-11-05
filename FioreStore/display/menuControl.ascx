<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuControl.ascx.cs" Inherits="FioreStore.display.menuControl" %>
<asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <li id="product-menu__item">
                            <a href="../Product.aspx?id=<%# Eval("ProID") %>"><%# Eval("Name") %></a>
                            
                            <%--<asp:LinkButton ID="LinkButton1" runat="server"
                            Text='' ></asp:LinkButton>--%></li>
                    </ItemTemplate>
                </asp:DataList>