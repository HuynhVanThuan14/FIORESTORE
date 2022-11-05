<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="FioreStore.Administrator" ValidateRequest="false" %>

<%@ Register Src="~/admin/adminControl.ascx" TagPrefix="uc1" TagName="adminControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:adminControl runat="server" ID="adminControl" />
        </div>
    </form>
</body>
</html>
