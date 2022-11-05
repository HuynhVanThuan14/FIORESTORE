<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="productNewControl.ascx.cs" Inherits="FioreStore.display.Product.productNewControl" %>
<asp:Repeater ID="rptProduct" runat="server">
    <ItemTemplate>
        <div class="relate-product">
            <div class="relate-product__img">
                <a href="../../ProductDetail.aspx?id=<%#: Eval("ProDelID") %>">
                    <img src="Image/<%#: Eval("Image") %>" alt="hoa" /></a>
            </div>

            <div class="relate-product__main">
                <a class="title" href="../../ProductDetail.aspx?id=<%#: Eval("ProDelID") %>"><%#: Eval("Name") %></a>
                <div class="star" style="color: #49860d;font-size:10px;margin: 4px 0">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="price" style="font-size: 15px; margin: 0"><%#: Eval("Price") %></p>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>