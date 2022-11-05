<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FioreStore._Default" %>

<%@ Register Src="~/display/menuControl.ascx" TagPrefix="uc1" TagName="menuControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="background-color: #F5F5F5;">
        <div class="container" style="display: flex; justify-content: space-between;">
            <div style="flex-basis: 25%;">
                <uc1:menuControl runat="server" ID="menuControl" />
            </div>

            <div class="banner" style="flex-basis: 75%;">
                <div class="banner-left">
                    <div class="banner-top hover-banner">
                        <a href="#">
                            <img src="Image/slider2.jpg"
                                alt=""></a>
                    </div>
                    <div class="banner-bot hover-banner">
                        <div class="banner-bot-left">
                            <a href="#">
                                <img src="Image/banner1.jpg"
                                    alt=""></a>
                        </div>

                        <div class="banner-bot-right hover-banner">
                            <a href="#">
                                <img src="Image/banner2.jpg"
                                    alt=""></a>
                        </div>
                    </div>
                </div>

                <div class="banner-right hover-banner">
                    <a href="#">
                        <img src="Image/banner3.jpg" alt=""></a>
                </div>
            </div>
        </div>
    </div>

    <div id="top-new_product" class="h3_header">
        <div class="container">
            <h3>Top sản phẩm mới nhất</h3>
        </div>

        <div class="new-product__wrapper">
            <div class="container">
                <asp:Repeater ID="rptNewProduct" runat="server">
                    <ItemTemplate>

                        <div style="display: inline-block; margin: 0 0 12px 0">
                            <div class="new-product">
                                <div class="new-product__image">
                                    <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>">
                                        <img
                                            src='Image/<%#: Eval("Image") %>'
                                            alt="hoa" /></a>
                                </div>

                                <div class="new-product__content">
                                    <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>"><%#: Eval("Name") %></a>
                                    <div class="new-product__content--star">
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                    </div>
                                    <div class="new-product__content--price"><%#: Eval("Price") %></div>
                                    <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>" class="new-product__content--button">Chi tiết</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <a href="Product.aspx" class="see-all">SEE ALL PRODUCT</a>

        <div class="container">
            <div class="top-new_product__banner">
                <div style="width: 49%">
                    <a href="#">
                        <img src="Image/bg_top1.jpg" alt="Alternate Text" /></a>
                </div>
                <div style="width: 49%">
                    <a href="#">
                        <img src="Image/BANNER4.jpg" alt="Alternate Text" /></a>
                </div>
            </div>
        </div>
    </div>

    <div id="top-price_product" class="h3_header">
        <h3>Top sản phẩm có giá cao nhất</h3>
        <div class="container">
        <asp:Repeater ID="rptPriceProduct" runat="server">
            <ItemTemplate>
                <div class="product__cart" style="display: inline-block; background: white">
                    <div class="product__cart--image-overlay"></div>
                    <div class="product__cart--image">
                        <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>"><img
                            src="Image/<%#: Eval("Image") %>"
                            alt="hoa" /></a>
                        
                    </div>
                    <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>"><%#: Eval("Name") %></a>
                    <div class="product__cart--star">
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                    </div>
                    <div class="product__cart--price">
                        <del style="font-size: 13px; color: rgb(167, 168, 168)">720.000đ</del>
                        <span style="font-size: 18px; color: red; font-weight: 700"><%#: Eval("Price") %></span>
                    </div>
                    <a  id="btnChiTiet" href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>">Chi tiết</a>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>
        <a href="Product.aspx" class="see-all">SEE ALL PRODUCT</a>

    </div>


</asp:Content>
