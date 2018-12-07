//var valores = [];
//var valorAno = 2012;
//var areass = ['Metropolitana', 'Cibao Nordeste', 'Cibao Noroeste', 'Cibao Norte', 'Cibao Sur', 'Del Valle', 'Enriquillo', 'Higuamo', 'Valdesia', 'Yuma'];
//var i = 0;

//$(function () {
//    $.getJSON("../Assets/js/mapael/test-data.json", function (data) {

//        //$(".knob").knob({
//        //    release: function (value) {
//        //        mapa(value, data, i)
//        //    }
//        //});

//        mapa(2012, data, i)
//    })
//});

//function mapa(value, data, i) {

//    i = 0;
//    $.each(areass, function (index, cosa) {
//        valores[i] = data[value]['areas'][areass[i]]['value']
//        console.log(valores[i]);
//        i++
//    })

//    $world = $(".dominican-republic");
//    $world.mapael({
//        map: {
//            name: "dominican_republic",
//            defaultArea: {
//                attrs: {
//                    fill: "#fff",
//                    stroke: "#fff",
//                    "stroke-width": 0.3
//                },

//                text: {
//                    attrs: {
//                        fill: "#000"
//                    }

//                },

//            },
//            zoom: {
//                enabled: true
//                , step: 0.25
//                , maxLevel: 20
//            }
//        },
//        legend: {
//            area: {
//                display: true,
//                title: "Country population",
//                marginBottom: 7,
//                slices: [
//                    {
//                        max: 5,
//                        attrs: {
//                            fill: "#FEF1DB"
//                        },
//                        label: "Less than 5"
//                    },
//                    {
//                        min: 5,
//                        max: 10,
//                        attrs: {
//                            fill: "#FDD399"
//                        },
//                        label: "Between 5 and 10"
//                    },
//                    {
//                        min: 10,
//                        max: 15,
//                        attrs: {
//                            fill: "#F9A56D"
//                        },
//                        label: "Between 10 and 15"
//                    },
//                    {
//                        min: 15,
//                        max: 20,
//                        attrs: {
//                            fill: "#F2724A"
//                        },
//                        label: "Between 15 and 20"
//                    },
//                    {
//                        min: 20,
//                        max: 25,
//                        attrs: {
//                            fill: "#D93C27"
//                        },
//                        label: "Between 20 and 25"
//                    },
//                    {
//                        min: 25,
//                        attrs: {
//                            fill: "#B21F24"
//                        },
//                        label: "More than 25"
//                    }
//                ]

//            },

//        },

//        areas: {
//            "Metropolitana": {
//                text: { content: valores[0] },
//                value: valores[0],
//                tooltip: {
//                    "content": "<span style=\"font-weight:bold;\">Distrito Nacional</span><br />population :" + valores[0]
//                }
//            },
//            "Cibao Nordeste": {
//                text: { content: valores[1] },
//                value: valores[1],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Cibao Nordeste</span><br />population :" + valores[1]
//                }

//            },
//            "Cibao Noroeste": {
//                text: { content: valores[2], x: 436.275, y: 133.02999999999997 },
//                value: valores[2],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Cibao Noroeste</span><br />population :" + valores[2]
//                }
//            },
//            "Cibao Norte": {
//                text: { content: valores[3] },
//                value: valores[3],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Cibao Noroeste</span><br />population :" + valores[3]
//                }
//            },
//            "Cibao Sur": {
//                text: { content: valores[4] },
//                value: valores[4],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Cibao Sur</span><br />population :" + valores[4]
//                }
//            },
//            "Del Valle": {
//                text: { content: valores[5] },
//                value: valores[5],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Del Valle</span><br />population :" + valores[5]
//                }
//            },
//            "Enriquillo": {
//                text: { content: valores[6] },
//                value: valores[6],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Enriquillo</span><br />population :" + valores[6]
//                }
//            },
//            "Higuamo": {
//                text: { content: valores[7] },
//                value: valores[7],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Higuamo</span><br />population :" + valores[7]
//                }
//            },
//            "Valdesia": {
//                text: { content: valores[8] },
//                value: valores[8],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Valdesia</span><br />population :" + valores[8]
//                }
//            },
//            "Yuma": {
//                text: { content: valores[9] },
//                value: valores[9],
//                "tooltip": {
//                    "content": "<span style=\"font-weight:bold;\">Región Yuma</span><br />population :" + valores[9]
//                }
//            }
//        }
//    });

//}