<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="FioreStore.Product" %>

<%@ Register Src="~/display/menuCountControl.ascx" TagPrefix="uc1" TagName="menuCountControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="product-page">

        <div>
            <div class="product__header container">
                <div class="product__header--left">
                    <a style="text-decoration: none; color: black; font-weight: 700;" href="Default.aspx">Trang chủ</a> >> <a style="text-decoration: none; font-weight: 700; color: green;" href="#">Cửa hàng</a>
                </div>

                <div class="product__header--search">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Tìm kiếm sản phẩm ..."></asp:TextBox>
                    <%--<asp:Button ID="Button1" runat="server" Text='' />--%>
                    <asp:LinkButton ID="Button1" runat="server" OnClick="Button1_Click"><i class="fa-solid fa-magnifying-glass"></i></asp:LinkButton>
                </div>

                <div class="product__header--soft">
                    <span>Showing all 8 results
                    </span>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="product__content--wrapper">
            <div class="container">
                <div class="product__content">
                    <div class="product__content--menu">
                        <h3 style="margin-bottom: 30px;">Danh mục sản phẩm   </h3>
                        <uc1:menuCountControl runat="server" ID="menuCountControl" />
                    </div>


                    <div class="product__content--main">
                        <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label><br />
                            <asp:Repeater ID="rptProduct" runat="server">
                                <ItemTemplate>
                                    <div class="product__cart product__cart1" style="display: inline-block; background: white">
                                        <div class="product__cart--image-overlay"></div>
                                        <div class="product__cart--image">
                                            <a href="ProductDetail.aspx?id=<%#: Eval("ProDelID") %>">                                            <img
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
        </div>
    </div>
</asp:Content>
