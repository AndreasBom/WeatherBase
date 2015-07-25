<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="SmhiDemo.Pages.Graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="Stylesheet"/>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js" ></script>

        <%-- //Kod lånad, men förändrad och anpassad till min kontext. http://dotnetawesome.blogspot.se/2013/12/autocomplete-textbox-without-webservice.html  --%>
        <script type="text/javascript">
            $(function () {
                $('#<%=TextBoxSearchWindTemp.ClientID%>').autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: 'Graph.aspx/GetStationName',
                                data: "{ 'stationName':'" + request.term + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    response($.map(data.d, function(item) {
                                        return { value: item }
                                    }));
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    alert(textStatus + "Ingen station hittades");
                                }
                            });
                        }
                    });
                });
    </script>  


</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">




    <%-- Javascript -> render chart --%>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart', 'line'] });
        //Kod lånad, men förändrad och anpassad till min kontext.  http://www.c-sharpcorner.com/UploadFile/4d9083/how-to-create-google-charts-in-Asp-Net-with-json879/
        
        //Ajax call to method GetChartDataWind
        $(document).ready(function() {
            if (<%= TextBoxSearchWindTemp.ClientID %>.value !== "Mätstation") {
                $(function () {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        contentType: 'application/json',
                        url: 'Graph.aspx/GetChartDataWind',
                        data: '{}',
                        success: function (response) {
                            drawchartWind(response.d); // calling method                      
                        },
                        error: function () {
                            //Letting server handle error response
                        }
                    });
                });
            }
        });
        //GetDataChartTemperature
        $(document).ready(function() {
            if (<%= TextBoxSearchWindTemp.ClientID %>.value !== "Mätstation") {
                $(function () {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        contentType: 'application/json',
                        url: 'Graph.aspx/GetChartDataTemperature',
                        data: '{}',
                        success: function (response) {
                            drawchartTemp(response.d); // calling method                      
                        },
                        error: function () {
                            //Letting server handle error response
                        }
                    });
                });
            }
        });
        function drawchartWind(dataValues) {
            var data = new google.visualization.DataTable(dataValues);
            //Columns
            data.addColumn('string', 'Time');
            data.addColumn('number', 'Vindhastighet (m/s)');
            //Add data to rows
            for (var i = 0; i < dataValues.length; i++) {
                var time = dataValues[i].Time.toString().substr(11, 5);
                data.addRow([time, dataValues[i].WindVelocity]);
            }
            // Instantiate and draw chart
            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data,
            {
                title: "Vindhastighet senaste dygnet för " + dataValues[0].Station,
                position: "top",
                fontsize: "14px",
                chartArea: { width: '50%' }
            });
        }
        function drawchartTemp(dataValues) {
            var data = new google.visualization.DataTable(dataValues);
            //Columns
            data.addColumn('string', 'Time');
            data.addColumn('number', 'Mintemperatur');
            data.addColumn('number', 'Maxtemperatur');
            data.addColumn('number', 'Medeltemperatur');
            //Add data to rows
            for (var i = 0; i < dataValues.length; i++) {
                
                var time = dataValues[i].Time.toString().substr(0, 10);
                
                
                data.addRow([time, dataValues[i].MinTemp, dataValues[i].MaxTemp, dataValues[i].MeanTemp ]);
                
            }
            // Instantiate and draw chart
            var chart = new google.visualization.LineChart(document.getElementById('chart_temp'));
            chart.draw(data,
            {
                title: "Temperatur senaste månaderna för " + dataValues[0].Station,
                position: "top",
                fontsize: "14px",
                chartArea: { width: '50%' }
            });
        }
    </script>
    
    

    
    
    <div class="container">

        <div class="text-center search-wrapper">
            <h4>Sök vind och temperatur</h4>
            <asp:TextBox ID="TextBoxSearchWindTemp" runat="server" 
                CssClass="form-control form ui-widget" 
                Text="Mätstation"></asp:TextBox>
            <asp:Button ID="ButtonSearch" runat="server" 
                Text="Sök" 
                CssClass="btn btn-info"
                OnClick="ButtonSearch_OnClick"/>
        
        <asp:PlaceHolder ID="PlaceHolderError" runat="server">
            <asp:Label ID="LabelError" runat="server" Text="" CssClass="error-ajax-search"></asp:Label>
        </asp:PlaceHolder>
        </div>
        
        <%--Chart--%>
        <div id="chart_div" class="charts"></div>
        <div id="chart_temp" class="charts"></div>
    </div>
    
    
    
    
    

    
    <%-- onFocus deletes initial value from textbox --%>
    <script type="text/javascript">
        document.getElementById("<%= TextBoxSearchWindTemp.ClientID %>").addEventListener('focus', function () {
            this.value = "";
        });
    </script>
    
</asp:Content>


