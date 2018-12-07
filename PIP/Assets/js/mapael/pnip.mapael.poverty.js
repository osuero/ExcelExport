
$(".mapcontainer").mapael({
    map: {
        name: "dominican_republic",
        defaultArea: {
            attrs: {
                stroke: "#fff",
                "stroke-width": 1
            },
            attrsHover: {
                "stroke-width": 2
            }
        }
    },
    defaultArea: {
        attrs: {
            fill: "#5ba4ff",
            stroke: "#99c7ff",
            cursor: "pointer"
        },
        attrsHover: {
            animDuration: 0
        },
        text: {
            attrs: {
                cursor: "pointer",
                "font-size": 10,
                fill: "#000"
            },
            attrsHover: {
                animDuration: 0
            }
        }   
    },
    areas: {
        "Metropolitana": {
            "value": 27.6,
            attrs: {
                fill: "#e97f09"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Distrito Nacional</span>"
            },
            eventHandlers: {
                click: function (mapElem) {               
                    href: (ModalMapa("Región Ozama o Metropolitana", "../Assets/img/modales/regionEnriquillo.png"))
                }
            }
        },
        "Valdesia": {
            "value": 13.7,
            attrs: {
                fill: "#2c775e"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Cibao Nordeste</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Valdesia", "../Assets/img/modales/regionValdesia.png"))
                }
            }
        },
        "Enriquillo": {
            "value": 6.7,
            attrs: {
                fill: "#3ea985"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Cibao Noroeste</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Enriquillo", "../Assets/img/modales/regionEnriquillo.png"))
                }
            }

        },
        "Cibao Noroeste": {
            "value": 6.5,
            attrs: {
                fill: "#822209"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Cibao Noroeste</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Cibao Noroeste", "../Assets/img/modales/regionCibaoNoroeste.png"))
                }
            }

        },
        "Cibao Nordeste": {
            "value": 6.9,
            attrs: {
                fill: "#a22a0b"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Cibao Sur</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Cibao Nordeste", "../Assets/img/modales/regionCibaoNordeste.png"))
                }
            }

        },
        "Yuma": {
            "value": 5.7,
            attrs: {
                fill: "#c86d08"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Del Valle</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Yuma", "../Assets/img/modales/regionYuma.png"))
                }
            }

        },
        "Cibao Norte": {
            "value": 13.9,
            attrs: {
                fill: "#c2320d"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Enriquillo</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Cibao Norte", "../Assets/img/modales/regionCibaoNorte.png"))
                }
            }

        },
        "Higuamo": {
            "value": 7.2,
            attrs: {
                fill: "#874a05"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Higuamo</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Higuamo", "../Assets/img/modales/regionHiguamo.png"))
                }
            }

        },
        "Del Valle": {
            "value": 4.8,
            attrs: {
                fill: "#359071"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Valdesia</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Del Valle", "../Assets/img/modales/regiondelValle.png"))
                }
            }

        },
        "Cibao Sur": {
            "value": 6.9,
            attrs: {
                fill: "#e23a0f"
            },
            tooltip: {
                "content": "<span style=\"font-weight:bold;\">Región Yuma</span>"
            },
            eventHandlers: {
                click: function (mapElem) {
                    href: (ModalMapa("Región Cibao Sur", "../Assets/img/modales/regionCibaoSur.png"))
                }
            }
        }
    }
});
