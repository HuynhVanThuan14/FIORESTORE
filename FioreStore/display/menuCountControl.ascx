<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuCountControl.ascx.cs" Inherits="FioreStore.display.menuCountControl" %>

<asp:DataList ID="DataList1" runat="server">
    <ItemTemplate>
        <li style="border-bottom: 1px solid #ccc; ">
            <a href='../Product.aspx?id=<%#: Eval("ProID") %>' style="width: 180px; display: inline-block; text-decoration: none;padding: 12px 0; color:#49860d"><%# Eval("Name") %></a>
            (<asp:Label ID="lblCountProduct" runat="server" Text='<%# Eval("Count")%>'></asp:Label>)
        </li>
    </ItemTemplate>
</asp:DataList>

