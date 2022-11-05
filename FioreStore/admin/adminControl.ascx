<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adminControl.ascx.cs" Inherits="FioreStore.admin.adminControl" %>
<%@ Register Src="~/admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>

<div>Banner Admin</div>

<div class="admin__flex">
    <div class="admin__left-menu">
        <uc1:Menu runat="server" id="Menu" />
    </div>

    <div class="admin__content">
        <asp:PlaceHolder ID="plLoad" runat="server"></asp:PlaceHolder>
    </div>
</div>