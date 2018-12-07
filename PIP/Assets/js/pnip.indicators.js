//function ExportToExcel() {
//    var htmltable = document.getElementById('example');
//    var html = htmltable.outerHTML;
//    window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
//}

//function ExportToExcel() {

function ModalMapa(titulo, ruta) {
    $(".modal-title").text(titulo)
    $('#imgmapa1').attr('src', ruta);
    $('#openModal1').modal('show');
}

function mostrar() {
        $("#tabs").css({ "display": "table"});
    };

function forceSVGToPNGRevenge() {
    //HERE
    var theSVG = $("div.map svg")[1];
    //----

    var svgString = new XMLSerializer().serializeToString(theSVG);

    var dimensions = { width: theSVG.width.baseVal.value, height: theSVG.height.baseVal.value };
    var canvas = $("<canvas>", dimensions)[0];
    var ctx = canvas.getContext("2d");
    var DOMURL = self.URL || self.webkitURL || self;
    var img = new Image();
    var svg = new Blob([svgString], { type: "image/svg+xml;charset=utf-8" });
    var url = DOMURL.createObjectURL(svg);

    img.onload = function () {
        var theIMG = $("<img>")[0];
        img.width = dimensions.width;
        img.height = dimensions.height;

        canvas.width = dimensions.width;
        canvas.height = dimensions.height;

        ctx.drawImage(img, 0, 0, dimensions.width, dimensions.height);
        console.log(canvas);
        var png = canvas.toDataURL("image/png");

        theIMG.src = png;
        theIMG.width = dimensions.width;
        theIMG.height = dimensions.height;

        var link = document.createElement("a");
        link.download = 'pobreza.png';
        link.href = png;

        document.body.appendChild(link);
        link.click();

        // Cleanup the DOM
        // Why?
        document.body.removeChild(link);
        delete link;

        DOMURL.revokeObjectURL(png);
    };
    img.src = url;
}

//function datatableexport() {
//    if (!$('.content-placeholder').find("table").hasClass("dataTable")) {
//        $('.content-placeholder').find("table").DataTable({
//            dom: 'Bfrtip',
//            buttons: [
//                'copy', 'csv', 'excel', 'pdf', 'print'
//            ]
//        });
//    }
//}


$(function () {

    /* ========================================================================
     * CONFIGURACIÓN GENERAL
     * ======================================================================== */

    // Variables globales
    // ==================================
    var map = $('.dominican-republic');


    new CBPFWTabs(document.getElementById('tabs'));

    // Valores predeterminados dataTables
    // ==================================

    $.extend(true, $.fn.dataTable.defaults, {
        "searching": false,
        "paging": false,
        "ordering": false,
        "info": false,
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        dom: 'Bfrtip',
        buttons: [
                 {
                     extend: 'excelHtml5',
                     title: $("#IndicatorId").find("option:selected").text()
                 }

        ]
    });

    // Valores predeterminados Bootstrap Drill Down
    // ============================================

    $('#drilldown').drilldown({
        wrapper_class       :   'drilldown panel panel-success',
        menu_class          :   'drilldown-menu',
        submenu_class       :   'dd-nav',
        parent_class        :   'dd-parent',
        parent_class_link   :   'dd-parent-a',
        active_class        :   'active',
        header_class_list   :   'breadcrumb',
        header_class        :   'breadcrumbwrapper',
        class_selected      :   'selected',
        event_type          :   'click',
        hover_delay         :   300,
        speed               :   'fast',
        save_state          :   false,
        show_count          :   false,
        count_class         :   'dd-count',
        icon_class          :   'chevron-right float-right dd-icon',
        link_type           :   'breadcrumb', //breadcrumb , link, backlink
        reset_text          :   'Categoría', // All
        default_text        :   'Seleccione categoría',
        show_end_nodes      :   true, // drill to final empty nodes
        hide_empty          :   true, // hide empty menu when menu_height is set, header no effected
        menu_height         :   '200px', // '200px' , false for auto height
        show_header         :   false,
        header_tag          :   'div',// h3
        header_tag_class    :   'list-group-item active' // hidden list-group-item active
    });


    //$('#pnip-resultados-filtro').on('submit', function (e) {
    //    e.preventDefault();

    //    var options = $(this).serialize();

        

    //    componerInforme(options);
    //});

    /* ========================================================================
     * SELECCIÓN DE INDICADORES
     * ======================================================================== */

    $('#drilldown ul li a').on('click', function (e) {
        e.preventDefault();

        var indicatorId = $(this).data('indicator-id');

        var options = "IndicatorId=" + indicatorId;

        //$("#tabs").css({ "display": "table" });


        componerInforme(options);

        //console.log("indicator id: ", options);

    });

    /* ========================================================================
     * INFORME
     * ======================================================================== */

    function componerInforme(options) {

        // Variables 

        var h3 = $('header > h3'),
            h4 = $('header > h4'),
            h5 = $('header > h5'),
            h6 = $('header > h6'),
            url = '/indicators/load?' + options,
            //datos = new Object(),
            tabulated = $('table.pnip-cuadro-series');

        //var timeline = $('#timeline');
        //var legendRange = $('.legend-range-bar');
        //var range = new Object();

        //legendRange.jRange({
        //    from: 0,
        //    to: 100,
        //    step: 0.01,
        //    scale: [0, 100],
        //    //format: '%s',
        //    format: (value) => { return parseFloat(value).toFixed(1); },
        //    width: 230,
        //    theme: "theme-gradient",
        //    showLabels: true,
        //    disable: true,
        //    //onstatechange: function () {
        //    //    console.log("cambio la vaina: ", this);
        //    //}
        //});


        

        $.ajax({
            url: url,
            beforeSend: function () {
                if ($.fn.dataTable.isDataTable(tabulated)) {
                    tabulated.dataTable().fnDestroy();
                    //tabulated.empty();
                    
                    //if ($('#timeline').hasClass('rangeslide')) { timeline.destroy(); }
                    $('#timeline').empty();
                    $('.widget-timeline .timeline-year .play').off('click');
                    //timeline.refresh();
                    
                    //$('.timeline-container .time').append("<div id='timeline'></div>");

                    //reset legend
                    $('.legend-range-bar').next('div').remove();
                    $('.legend-range-bar').remove();
                    $('.legend-range').append('<input type="hidden" class="legend-range-bar" value="0.0" />');

                    //legendRange.jRange('reset');

                    
                    


                }
                
            },
            success: function (json) {

                

                /* codigo de handlerbars*/

                var theTemplateScript = $("#expressions-template").html();
                // Compile the template
                var theTemplate = Handlebars.compile(theTemplateScript);
                // Pass our data to the template
                var theCompiledHtml = theTemplate(json.metaDato);
                // Add the compiled html to the page
                $('.content-placeholder').html(theCompiledHtml);
                
                var math = document.getElementsByClassName('content-placeholder');
                MathJax.Hub.Queue(["Typeset", MathJax.Hub, math]);


                var data        = json;
                var year        = GetYearScope(data);
                var legendRange = $('.legend-range-bar');
                var range       = new Object();

                var name        = $('.module-header .indicator-name');
                var category    = $('.module-header .indicator-category');
                var sources     = $('.indicator-sources');

                //console.log(data)


                name.html(json.source.Título.text.content);
                category.html(json.source.Categoría.text.content);
                sources.html(json.source.Fuente.text.content);

                var title = json.source.Título.text.content;
                var source = json.source.Fuente.text.content;



                $('#Source').text(source);
                $('#title').html('<i class="circle" style="color:#F69;"></i>' + title + '<a href="" data-source="loss" class="source default"><svg><use xlink:href="#shape-info"></use></svg></a>');





                tabulated.DataTable({
                    "data": data.rows,
                    "columns": data.columns,
                });

                $('.content-placeholder').find("table").DataTable({
                    dom: 'Bfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ],
                    "columnDefs": [
                      { "width": "10px", "targets": 0 },
                      { "width": "40px", "targets": 1 },
                     
                     
                    ]
                });
                

                $('#titulo').text(title);
                $('#fuente').text(source);

                map.mapael({
                    map: {
                        name: "dominican_republic",
                        defaultArea: {
                            attrs: {
                                fill: "#fff",
                                stroke: "#fff",
                                "stroke-width": 0.3
                            },

                            text: {
                                attrs: {
                                    fill: "#000"
                                }

                            },

                            eventHandlers: {
                                mouseover: function (e, id, mapElem, textElem, elemOptions) {
                                    //$.fn.mapael.elemHover(mapElem.paper, mapElem, textElem);

                                    //console.log("e: ", e);
                                    //console.log("id: ", id);
                                    //console.log("mapElem: ", mapElem);
                                    //console.log("textElem: ", textElem);
                                    //console.log("elemOptions: ", elemOptions);

                                    //console.log("hover map value: ", elemOptions.value);

                                    legendRange.jRange('setValue', elemOptions.value);

                                    //console.log("legendRange: ", legendRange);

                                    $(legendRange).next().addClass("active");
                                },
                                mouseout: function (e, id, mapElem, textElem) {

                                    $(legendRange).next().removeClass("active");

                                    // Même chose pour le mouseout :
                                    //$.fn.mapael.elemOut(paper, mapElem, textElem);

                                    //legendRange.jRange('disable');
                                },
                            }
                            
                        },
                        zoom: {
                            enabled: false
                            , step: 0.25
                            , maxLevel: 20
                        }
                    },
                    legend: data.legend,
                    areas: data.map[year.first]['areas']
                });



                range = GetBoundaryValues(year.first, data.map);

                //console.log("range: ", range);

                //legendRange.jRange('updateRange', String(range.min + "," + range.max));
                //legendRange.jRange('updateRender', [range.min, range.max]);

                legendRange.jRange({
                    from: range.min,
                    to: range.max,
                    step: 0.01,
                    scale: [range.min, range.max],
                    //format: '%s',
                    format: (value) => { return parseFloat(value).toFixed(1); },
                    width: 230,
                    theme: "theme-gradient",
                    showLabels: true,
                    disable: true
                    //onstatechange: function () {
                    //    console.log("cambio la vaina: ", this);
                    //}
                });



                

                var timeline = rangeslide('#timeline', {
                    data: year.list,
                    showLabels: true,
                    showTicks: false,
                    labelsContent: null,
                    trackHeight: 4,
                    thumbWidth: 12,
                    thumbHeight: 12,
                    handlers: {
                        "labelClicked": [mapDataUpdate],
                        "trackClicked": [mapDataUpdate]
                    }
                });




                function mapDataUpdate(year, element) {

                    var updatedOptions = { 'areas': {} };
                    

                    updatedOptions.areas = data.map[year]['areas'];
                    
                    //console.log("range: ", range);


                    map.trigger('update', [{
                        mapOptions: updatedOptions,
                        animDuration: 300,
                        afterUpdate: function (mapOptions) {
                            //Se necesita volver a llamar la función update porque con la animación configurada no se actualizan los textos
                            map.trigger('update', [{
                                mapOptions: updatedOptions
                            }]);

                            


                            range = GetBoundaryValues(year, data.map);
                            
                            //console.log("year: ", year);

                            //var _range = GetBoundaryValues(year, data.map);
                            //console.log("range: ", range);

                            //console.log("range string: ", String(range.min + "," + range.max));

                            
                            legendRange.jRange('updateRange', String(range.min + "," + range.max));
                            //legendRange.jRange('updateRange', '5.1,27.9');
                            legendRange.jRange('updateScale', [range.min, range.max]);
                            //legendRange.jRange('updateRender', [range.min, range.max]);
                            
                        }
                    }]);
                }

                //function mapLegendUpdate(year, element) {

                //    console.log("map legend update: ", year);
                //}








                $('.widget-timeline .timeline-year .play').on('click', function () {

                    var clicks = $(this).data('clicks');

                    if (clicks) {

                        //timeline.destroy();

                        timeline.setOption("autoPlay", false);
                        timeline.setOption("showTrackProgress", false);

                        //$(this).children('.play-icon').css("display", "block");
                        //$(this).children('.stop-icon').next("display", "none");

                        $(this).removeClass('active');

                    } else {

                        $(this).addClass('active');

                        //$(this).children('.play-icon').css("display", "none");
                        //$(this).children('.stop-icon').next("display", "block");

                        timeline.destroy();

                        timeline = rangeslide('#timeline', {
                            data: year.list,
                            showLabels: true,
                            autoPlay: true,
                            showTrackProgress: true,
                            showTicks: false,
                            labelsContent: null,
                            trackHeight: 4,
                            thumbWidth: 12,
                            thumbHeight: 12,
                            handlers: {
                                "valueChanged": [mapDataUpdate]
                            }
                        });

                        //timeline.setOption("autoPlay", true);
                        //timeline.setOption("showTrackProgress", true);
                        //timeline.setOption("handlers", { "valueChanged": [mapDataUpdate] });

                    }

                    $(this).data("clicks", !clicks);
                });

            },
            "dataType": "json"
        });


    }


    /* ========================================================================
     * HERRAMIENTAS MAPA
     * ======================================================================== */

    var reset       = $('#module-map-controls .reset-map'),
        zoomIn      = $('#module-map-controls .zoom-in'),
        zoomOut     = $('#module-map-controls .zoom-out'),
        hideModules = $('#module-map-controls .toggle-modules');

    zoomIn.on('click', function () {
        map.trigger('zoom', {
            level: "+1"
        });
    });

    zoomOut.on('click', function () {
        map.trigger('zoom', {
            level: "-1"
        });
    });

    reset.on('click', function () {
        map.trigger('zoom', {
            level: 0
        });
    });

    hideModules.on('click', function () {
        $(this).toggleClass('active');

        $('.module-toggle').each(function () {
            $(this).toggleClass('hide');
        });
    });



    /* ========================================================================
     * FUNCIONES UTILITARIAS
     * ======================================================================== */

    // Retorna los valores máximo/mínimo del indicador para el año seleccionado
    // ========================================================================

    function GetBoundaryValues(year, data) {

        var regions = ['Metropolitana', 'Cibao Nordeste', 'Cibao Noroeste', 'Cibao Norte', 'Cibao Sur', 'Del Valle', 'Enriquillo', 'Higuamo', 'Valdesia', 'Yuma'];
        var max;
        var min;
       
        for (var i = 0 ; i < regions.length ; i++) {
            if (!max || parseFloat(data[year]['areas'][regions[i]]['value']) > parseFloat(max))
                max = data[year]['areas'][regions[i]]['value'];

            if (!min || parseFloat(data[year]['areas'][regions[i]]['value']) < parseFloat(min))
                min = data[year]['areas'][regions[i]]['value'];
        }
       
        return JSON.parse('{ "min":' + min + ', "max":' + max + '}');

    }

    // Retorna el primer, último y conjunto de años disponibles
    // ========================================================

    function GetYearScope(data) {
        //console.log(data.columns)

        var _data = $.extend(true, {}, data);

        _data.columns.splice(0, 1);

        var years   = _data.columns;
        var list    = new Array();
        var first;
        var last;

        for (var i = 0 ; i < years.length ; i++) {
            if (!first || parseInt(years[i]['title']) < parseInt(first))
                first = parseInt(years[i]['title']);

            if (!last || parseInt(years[i]['title']) > parseInt(last))
                last = parseInt(years[i]['title']);

            list[i] = years[i]['title'];
        }

        return JSON.parse('{ "first":' + first + ', "last":' + last + ', "list" :' + JSON.stringify(list) + '}');
    }



}); // Document ready