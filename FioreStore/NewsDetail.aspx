<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="FioreStore.NewsDetail" %>

<%@ Register Src="~/display/Product/productNewControl.ascx" TagPrefix="uc1" TagName="productNewControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="news-wrapper">
        <div class="container" style="margin: 30px 90px; ">
            <a  style="text-decoration: none; color: black; font-weight: 700;" href="Default.aspx">Trang chủ</a> >> <a style="text-decoration: none; font-weight: 700; color: green;" href="News.aspx">Tin tức</a>
            <hr style="margin-top: 30px"/>
        
        </div>
        <div class="container news-wrapper__flex">
            <div class="news-content" style="margin-right: 40px">
                <div style="font-weight: 700; font-size: 20px; margin:  0;">
                    <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                </div>
                <div style="font-weight: 300; font-size: 18px; margin: 30px 0; font-style: italic;">
                    <asp:Literal ID="ltDesc" runat="server"></asp:Literal>
                </div>
                <div style="font-size: 16px; margin: 30px 0;">
                    <asp:Literal ID="ltContent" runat="server"></asp:Literal>

                </div>
                <div>
                    <asp:Image runat="server" ID="img" />
                </div>
                <div style="font-style: italic; text-align: right;">
                    Tác giả:
            <asp:Literal ID="ltAuthor" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="news-sub">
                <h3>Bài viết liên quan</h3>
                <asp:DataList ID="DataList2" runat="server" CssClass="news-sub__link">
                    <ItemTemplate>
                        <div class="news-sub__link-left">
                            <a href="NewsDetail.aspx?id=<%#:Eval("DelID") %>">

                                <img src='/Image/<%# Eval("Image") %>' />
                            </a>
                        </div>

                        <div class="news-sub__link-right">
                            <a href="NewsDetail.aspx?id=<%#:Eval("DelID") %>" class="title"><%# Eval("Title") %></a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>

                <div class="news-sub__product">
                    <h3 style="margin: 30px 0 10px 0">Sản phẩm mới</h3>
                    <uc1:productNewControl runat="server" ID="productNewControl" />
                </div>
            </div>
        </div>
    </div>
    <%--    <div class="container">
    </div>--%>

    <div class="container">
        <h3 style="margin: 40px 0 20px 0; border-bottom: 1px solid #ccc;">Tin tức khác</h3>
        <asp:DataList ID="DataList1" runat="server" CssClass="news-sub__link1">
            <ItemTemplate>
                <div>
                    <a href="NewsDetail.aspx?id=<%# Eval("DelID") %>"><%# Eval("Title") %></a>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
