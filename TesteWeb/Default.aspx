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

            <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="End" DataKeyField="ID" DataStartField="Start" DataSubjectField="Subject" Culture="pt-BR" DataSourceID="ObjectDataSource1" Height="600px">
<ExportSettings>
<Pdf PageTopMargin="1in" PageBottomMargin="1in" PageLeftMargin="1in" PageRightMargin="1in"></Pdf>
</ExportSettings>
                <Localization AllDay="Dia Todo" HeaderDay="Dia" HeaderMonth="Mês" HeaderMultiDay="Múltiplos dias" HeaderNextDay="Próximo dia" HeaderPrevDay="Dia anterior" HeaderTimeline="Tempo" HeaderToday="Hoje" HeaderWeek="Semana" HeaderYear="Ano" Show24Hours="24 horas..." />
            </telerik:RadScheduler>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Modelos.Tarefa" DeleteMethod="ExcluirrTarefa" InsertMethod="SalvarTarefa" SelectMethod="ListarTarefas" TypeName="Persistencia.PFluent" UpdateMethod="SalvarTarefa"></asp:ObjectDataSource>

        </div>
    </form>
</body>
</html>
