<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="MapView.aspx.cs" Inherits="SmhiDemo.Pages.MapView" EnableEventValidation="false" ViewStateMode="Disabled"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://cdn.leafletjs.com/leaflet-0.7.3/leaflet.css" />
    <script src="http://cdn.leafletjs.com/leaflet-0.7.3/leaflet.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <input type="hidden" name="HiddenLatitude"
        id="__Latitude"
        value=""
        runat="server" />
    <input type="hidden" name="HiddenLatitude"
        id="__Longitude"
        value=""
        runat="server" />
    <input type="hidden" name="HiddenLatitude"
        id="__LatLng"
        value=""
        runat="server" />


    <div class="col-sm-5">
        <div class="">
            <h2>Väderprognos</h2>
            <p>Välj plats på kartan</p>

            <div id="map"></div>
            <div class="btn-wrapper">
                <asp:Button ID="ButtonGetForcast" runat="server"
                    Text="Hämta väder"
                    CssClass="btn btn-default"
                    OnClick="ButtonGetForcast_OnClick" />
            </div>

        </div>

    </div>

    <div class="col-sm-7">
        <div class="panel panel-default observation-layer">
            <div class="panel-heading text-center">
                
                <p id="period" runat="server"></p>
            </div>
            <div class="table-responsive">
                <asp:ListView ID="ListViewForcast" runat="server">

                    <LayoutTemplate>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <td>
                                        Tid
                                    </td>
                                    <td>
                                        Temperatur
                                    </td>
                                    <td>
                                        Vind (Byvind)
                                    </td>
                                    
                                </tr>
                            </thead>
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                               <%# Eval("ValidTime") %> 
                            </td>
                            <td>
                                <%# Eval("T") %>&deg;C
                            </td>
                            <td>
                                <%# Eval("WS") %>m/s (<%# Eval("GUST") %>m/s)
                            </td>
                        
                        </tr>
                        
                        
                    </ItemTemplate>

                </asp:ListView>


            </div>
        </div>
    </div>


    <%--<script src="../Scripts/MapScript.js"></script>--%>
    <script type="text/javascript">

        //create map
        var map = L.map('map').setView([57.72, 14.21], 6);

        //map provider
        L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);

        /*************************************************************************/
        var la = document.getElementById("<%= __Latitude.ClientID %>").value || 57.72;
        var ln = document.getElementById("<%= __Longitude.ClientID %>").value || 14.21;

        var marker;

        //place marker on postback. Self running method
        var init = function () {
            marker = L.marker([la, ln], { draggable: true });
            if (la !== 57.72 && ln !== 14.21) {
                marker.addTo(map);
            }
        }();

        //When map is clicked: Saves lat and lng to hidden input-field, plus relocates marker
        function onMapClick(e) {
            la = e.latlng.lat.toString();
            ln = e.latlng.lng.toString();

            document.getElementById("<%=__Latitude.ClientID %>").value = la;
            document.getElementById("<%= __Longitude.ClientID %>").value = ln;
            document.getElementById("<%= __LatLng.ClientID %>").value = e.latlng;


            marker.setLatLng(e.latlng).update();
            marker.addTo(map);
        }

        //Eventlistender when map is clicked        
        map.on('click', onMapClick);

    </script>
</asp:Content>
