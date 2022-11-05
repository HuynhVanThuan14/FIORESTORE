<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="FioreStore.News" %>

<%@ Register Src="~/display/Product/productNewControl.ascx" TagPrefix="uc1" TagName="productNewControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 60px">
        <a style="text-decoration: none; color: black; font-weight: 700;" href="Default.aspx">Trang chủ</a> >> <a style="text-decoration: none; font-weight: 700; color: green;" href="News.aspx">Tin tức</a>
    </div>

    <div class="news-wrapper">
        <div class="container news-wrapper__flex">
            <asp:DataList ID="DataList1" runat="server" CssClass="news-content">
                <ItemTemplate>
                    <div class="content__left">
                        <a href="NewsDetail.aspx?id=<%#:Eval("DelID") %>">
                            <img src='/Image/<%# Eval("Image") %>' />
                        </a>
                    </div>

                    <div class="content__right">
                        <a href="NewsDetail.aspx?id=<%#:Eval("DelID") %>" class="title"><%# Eval("Title") %></a>
                        <br />
                        <a href="NewsDetail.aspx?id=<%#:Eval("DelID") %>" style="font-weight: 300">
                            <p>
                                <asp:Label runat="server" ID="lblDesc" Text='<%# Eval("Desc") %>'></asp:Label>
                            </p>
                        </a>
                    </div>


                </ItemTemplate>
            </asp:DataList>

            <div class="news-sub">
                <h3>Bài viết liên quan</h3>
                <asp:DataList ID="DataList2" runat="server" CssClass="news-sub__link">
                    <ItemTemplate>
                        <div class="news-sub__link-left">
                            <a href="NewsDetail.aspx?id=<%#:Eval("DelID") %>">
                                <%--<asp:ImageButton runat="server" ImageUrl="<%# Eval("Image") %>"/>--%>
                                <img src='/Image/<%# Eval("Image") %>' />
                            </a>
                        </div>

                        <div class="news-sub__link-right">
                            <a href="NewsDetail.aspx?id=<%#:Eval("DelID") %>" class="title"><%# Eval("Title") %></a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <%--          <div class="news-sub__link"></div>

          <div class="news-sub__product"></div>--%>
                <div class="news-sub__product">
                    <h3 style="margin: 30px 0 10px 0">Sản phẩm mới</h3>
                    <uc1:productnewcontrol runat="server" id="productNewControl" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
