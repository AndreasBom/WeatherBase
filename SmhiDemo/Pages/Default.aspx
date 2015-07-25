<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmhiDemo.Pages.Default" %>
<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SMHI's väder API</title>
    
    <%: Styles.Render("~/bundles/BootstrapCss") %>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/StyleSheet.css" rel="stylesheet" />
    
    <%-- fonts --%>
    <link href='http://fonts.googleapis.com/css?family=Gloria+Hallelujah' rel='stylesheet' type='text/css'>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <nav class="navbar navbar-default navbar-fixed-top"></nav>
        </div>
        <div class="container">
            
            <%-- Header --%>
            <div class="page-header">
                <img src="~/Media/weatherSymbol_xs.png" alt="SMHIdotNet logo" class="weather-logo"/>
                <h1 id="logo-name">SMHI<span style="font-family: 'Gloria Hallelujah', cursive; font-size: 0.7em; color: crimson">dot</span>Net</h1>
            </div>
            <%-- Main Content --%>
            <div class="container">
                <div class="row">
                    <%-- left --%>
                    <div class="col-sm-4">
                        <div class="panel panel-default box">
                            <div class="panel-heading">Parameter</div>
                            <%-- content parameters--%>
                            <div class="panel-body">
                                
                                <asp:Repeater ID="RepeaterParameters" 
                                    runat="server"
                                    ItemType="SmhiNet.Models.ParameterModel"
                                    SelectMethod="RepeaterParameters_GetData"
                                    OnItemCommand="RepeaterParameters_OnItemCommand">
                                    <ItemTemplate>
                                        <h3 class="link-heading">
                                             <asp:LinkButton ID="LinkButtonParameters" 
                                                runat="server">
                                                 <%#: Item.Title %>
                                             </asp:LinkButton>
                                        </h3>
                                        <h4 class="link-description"> <%#: Item.Summary %></h4>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                        </div>
                    </div>
                    <%-- middle --%>
                    <div class="col-sm-4">
                        <div class="panel panel-default box">
                            <div class="panel-heading">Station</div>
                            <%-- content stations --%>
                            <div class="panel-body">
                                <asp:Repeater ID="RepeaterStations" 
                                    runat="server"
                                    ItemType="SmhiNet.Models.WeatherStationModel"
                                    SelectMethod="RepeaterStations_GetData"
                                    OnItemCommand="RepeaterStations_OnItemCommand"
                                    >
                                    <ItemTemplate>
                                        <h3 class="link-heading">
                                            <asp:LinkButton ID="LinkButtonStations" 
                                                runat="server"
                                                >
                                                 <%#: Item.Name %>
                                             </asp:LinkButton>
                                        </h3>
                                        <h4 class="link-description"> <%#: Item.Title %></h4>
                                    </ItemTemplate>
                                    
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <%-- righ --%>
                    <div class="col-sm-4">
                        <div class="panel panel-default box">
                            <div class="panel-heading">Observation</div>
                            <%-- content Observations--%>
                            <div class="panel-body">
                                <asp:Repeater ID="RepeaterObservation" runat="server"
                                    ItemType="SmhiNet.Models.ObservationModel"
                                    SelectMethod="RepeaterObservation_GetData">
                                    <ItemTemplate>
                                        <h4 class="link-description"> <%#: Item.Value %></h4>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        
        </div>
        
    </form>
</body>
</html>
