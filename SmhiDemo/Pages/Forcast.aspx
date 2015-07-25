<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="Forcast.aspx.cs" Inherits="SmhiDemo.Pages.Forcast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <asp:Label ID="LabelCity" CssClass="CityLabel" runat="server" Text=""></asp:Label>

    <asp:Repeater ID="RepeaterForcast" runat="server"
        ItemType="SmhiDemo.Pages.ForcastWithImage"
        SelectMethod="RepeaterForcast_GetData">

        <ItemTemplate>
            <div class="col-xs-3 border">
                <div class="weather-padding width-restriction">
                    <div class="weather-border">
                        <asp:Image ID="ImageWeather" runat="server" CssClass="img-responsive " ImageUrl="<%# Item.ImageUrl %>" />
                        <p id="temperature"><%# Item.Temperature %>&deg;C</p>
                        <p id="date"><%# Item.Date %></p>
                        
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>



</asp:Content>

