<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="FioreStore.ProductDetail" %>

<%@ Register Src="~/display/Product/productRelateControl.ascx" TagPrefix="uc1" TagName="productRelateControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="product-detail">
        <div class="container" style="margin-bottom: 10px">
            <a style="text-decoration: none; color: black; font-weight: 700;" href="Default.aspx">Trang chủ</a> / <a style="text-decoration: none; font-weight: 700; color: green;"  href="#">
                <asp:Label ID="lblDanhmuc" runat="server" Text=""></asp:Label></a>
        </div>
        <asp:Repeater ID="rptProDetail" runat="server">
            <ItemTemplate>
                <div class="product-detail__wrapper">
                    <div class="product-detail__main">
                        <div class="product-detail__main--top">
                            <div class="product-detail__main--img">
                                <img
                                    src="Image/<%#: Eval("Image") %>"
                                    alt="hoa" />
                            </div>

                            <div class="product-detail__main--content">
                                <p><%#: Eval("Name") %></p>

                                <div class="star">
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                </div>
                                <div class="price"><%#: Eval("Price") %></div>
                                <div class="desc">
                                    <%#: Eval("Desc") %>
                                </div>
                                <!-- <input type="button" value="-" class="minus button is-form" /> -->

                                <div class="quantity">

                                    <asp:TextBox  ID="txtQuantity" Text="1" runat="server" ></asp:TextBox>
                                </div>
                                <asp:LinkButton OnClick="lnkCart_Click" runat="server" ID="lnkCart" style="text-decoration: none; background: #539414; display: inline-block; padding: 10px 16px; color: white; font-weight: 600; border-radius: 4px; margin: 15px 0 0 0;">
                                    Thêm vào giỏ hàng
                                </asp:LinkButton>

                                <p style="font-size: 16px; color: #d7102c; font-weight: 600">
                                    Gọi ngay: 0972.939.830 để có được giá tốt nhất!
                                </p>
                            </div>
                        </div>

                        <div class="product-detail__main--mid">
                            <p>
                                <%#: Eval("Content") %>
                            </p>
                            <img
                                src="Image/<%#: Eval("Image") %>"
                                alt="hoa" />
                            <p>
                                <%#: Eval("Content") %>
                            </p>
                            <img
                                src="Image/<%#: Eval("Image") %>"
                                alt="hoa" />
                            <p>
                                <%#: Eval("Content") %>
                            </p>
                        </div>


                    </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="product-detail__sub">
            <div class="sub-top">
                <div class="sub-top__flex">
                    <div class="sub-top__icon">
                        <i style="color: #f5cc39" class="fa-solid fa-truck"></i>
                    </div>
                    <div class="sub-top__content">
                        <h4>Giao hàng nhanh chóng</h4>
                        <p>chỉ trong vòng 24 giờ</p>
                    </div>
                </div>
                <div class="sub-top__flex">
                    <div class="sub-top__icon">
                        <i style="color: #608bd9" class="fa-solid fa-shield-halved"></i>
                    </div>
                    <div class="sub-top__content">
                        <h4>Sản phẩm chính hãng</h4>
                        <p>sản phẩm nhập khẩu 100%</p>
                    </div>
                </div>
                <div class="sub-top__flex">
                    <div class="sub-top__icon">
                        <i
                            style="color: #7abf2e"
                            class="fa-solid fa-arrow-rotate-left"></i>
                    </div>
                    <div class="sub-top__content">
                        <h4>Mua hàng tiết kiệm</h4>
                        <p>rẻ hơn từ 10% - 30%</p>
                    </div>
                </div>
                <div class="sub-top__flex">
                    <div class="sub-top__icon">
                        <i style="color: red" class="fa-solid fa-phone"></i>
                    </div>
                    <div class="sub-top__content">
                        <h4>Hotline mua hàng</h4>
                        <p>0972.939.830</p>
                    </div>
                </div>
            </div>
            <div class="sub-bot">
                <h3 style="margin-top:40px">Có thể bạn thích</h3>
                <uc1:productRelateControl runat="server" id="productRelateControl" />
            </div>
        </div>
    </div>


    <div class="product-detail__main--bot">
        <div class="container">
            <h3 style="color: #ff5622; margin: 16px;">Những sản phẩm liên quan</h3>

            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                    <div class="product__cart product__cart1" style="display: inline-block; background: white">
                        <div class="product__cart--image-overlay"></div>
                        <div class="product__cart--image">
                            <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>">
                                <img
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
                        <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>" id="btnChiTiet">Chi tiết</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </div>

</asp:Content>
