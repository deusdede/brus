<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesteWeb.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />

            <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="End" DataKeyField="ID" DataStartField="Start" DataSubjectField="Subject" Culture="pt-BR" DataSourceID="ObjectDataSource1"></telerik:RadScheduler>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListarTarefas" TypeName="Persistencia.PFluent"></asp:ObjectDataSource>

        </div>
    </form>
</body>
</html>
