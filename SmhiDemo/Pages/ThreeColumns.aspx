<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="ThreeColumns.aspx.cs" Inherits="SmhiDemo.Pages.ThreeColumns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <%-- left --%>
    <div class="col-sm-4">
        <div class="panel panel-default box">
            <div class="panel-heading">Parameter</div>
            <%-- content parameters--%>
            <div class="panel-body scrollable">
                
                <asp:Repeater ID="RepeaterParameters" runat="server"
                    ItemType="SmhiNet.Models.ParameterModel"
                    SelectMethod="RepeaterParameters_GetData"
                    OnItemCommand="RepeaterParameters_ItemCommand">

                    <ItemTemplate>
                        <h3 class="link-heading">
                            <asp:LinkButton ID="LinkButtonParameters"
                                runat="server">
                                                 <%#: Item.Title %>
                            </asp:LinkButton>
                        </h3>
                        <h4 class="link-description"><%#: Item.Summary %></h4>
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
            <div class="panel-body scrollable">
                <asp:Repeater ID="RepeaterStations" runat="server"
                    ItemType="SmhiNet.Models.WeatherStationModel" 
                    SelectMethod="RepeaterStations_GetData"
                    OnItemCommand="RepeaterStations_OnItemCommand">

                    <ItemTemplate>
                        <h3 class="link-heading">
                            <asp:LinkButton ID="LinkButtonStations" runat="server" 
                                Text="<%#: Item.Name %>"/>
                        </h3>
                        <h4 class="link-description"><%#: Item.Title %></h4>
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
            <div class="panel-body scrollable panel-result">
                <asp:Repeater ID="RepeaterObservation" runat="server"
                    ItemType="SmhiNet.Models.ObservationModel" 
                    SelectMethod="RepeaterObservation_GetData">
                    <HeaderTemplate>
                        
                    </HeaderTemplate>
                    <ItemTemplate>
                        <h4 class="link-description link-row">
                            <%#: Convert.ToDateTime(Item.Date)  %>: <%#: Item.Value %> <%#: Item.ParameterUnit %>
                        </h4>
                    </ItemTemplate>

                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
