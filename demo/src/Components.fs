namespace App

open Feliz.Bulma
open Feliz
open Fable.Core.JsInterop
open Feliz.ReactSpeedometer

type CitColors =
    static member lightBlue = "#40a8b7"
    static member green = "#8cbf41"
    static member yellow = "#fec903"
    static member red = "#e1053a"
    static member orange = "#e97305"
    static member darkBlue = "#102035"

type Package = { Name: string; Link: string }

type StyledComponents =

    static member Container (children: ReactElement list) =
        Html.div [
            prop.style [
                style.display.flex
                style.flexDirection.column
                style.padding 50
                style.maxWidth 1000
                style.margin (0,length.auto)
            ]
            prop.children children
        ]

    static member Row (children: ReactElement list) =
        Html.div [
            prop.style [
                style.alignItems.center
                style.display.flex
            ]
            prop.children children
        ]

    static member NavbarLink (label: string) link=
        Html.a [
            prop.style [ style.margin(20, 0, 20, 20); style.color "white"; style.fontSize 20; style.fontWeight.bold]
            prop.href link
            prop.text label
        ]

    static member Navbar () =
        let logo: obj = importDefault "./cit-logo.png"
        Html.div [
            prop.style [
                style.padding (0, 20)
                style.backgroundColor CitColors.darkBlue
                style.height 70
                style.color "white"
                style.display.flex
                style.justifyContent.spaceBetween
                style.alignItems.center
            ]
            prop.children [
                Html.div [
                    prop.style [
                        style.width 1000
                        style.margin (0, length.auto)
                        style.display.flex
                        style.justifyContent.spaceBetween
                        style.alignItems.center
                        style.padding (0, 40)
                    ]
                    prop.children [
                        StyledComponents.Row [
                            Html.img [
                                prop.style [
                                    style.height 50
                                ]
                                prop.src (unbox<string>logo)
                            ]
                            Bulma.title [
                                prop.style [
                                    style.color.white
                                    style.fontSize (length.rem 1.5)
                                ]
                                prop.text "Compositional IT"
                            ]
                        ]
                    ]
                ]
            ]
        ]

    static member SubHeading (label: string) =
        Bulma.subtitle [
            prop.style [
                style.borderBottom(2, borderStyle.solid, CitColors.darkBlue)
                style.marginTop 30
                style.paddingBottom 10
            ]
            prop.text label
        ]

    static member Link p =
        Html.a [
            prop.style [
                style.color CitColors.darkBlue
                style.fontWeight.bold
                style.borderBottom (2, borderStyle.solid, CitColors.darkBlue)
            ]
            prop.text p.Name
            prop.href p.Link
        ]

    static member Description (wrapperName: string) (wrappedComponent: string) nuget npm =
        Html.div [
            StyledComponents.SubHeading wrapperName
            Html.b $"Feliz style bindings for {wrappedComponent}"
            Bulma.content [
                Html.ul [
                    Html.li [
                        StyledComponents.Link nuget
                    ]
                    Html.li [
                        StyledComponents.Link npm
                    ]
                ]
            ]
        ]

    static member HeadingWithContent (title: string) (children: ReactElement) =
        Html.div [
            StyledComponents.SubHeading title
            children
        ]

    static member Checkbox updateProp =
        Bulma.input.checkbox [
            prop.style [
                style.height 30
                style.width 30
            ]
            prop.onClick updateProp
        ]

    static member LabelWithCircleButton (name: string) updater =
        Html.div [
            prop.style [ style.display.flex; style.justifyContent.spaceBetween; style.alignItems.center; style.marginBottom 20 ]
            prop.children [
                Html.b name
                StyledComponents.Checkbox updater
            ]
        ]

    static member CodeBlock (code: string) =
        Html.pre [
            prop.style [
                style.padding 20
                style.fontSize 15
                style.backgroundColor "#f5f5f5"
                style.borderRadius 5
            ]
            prop.text code
        ]

    static member Select (items: string list) (handler: Browser.Types.Event -> unit)=
        Bulma.select [
            prop.style [
                style.width 150
                style.border (1, borderStyle.solid, "#767676")

            ]
            prop.className "center-select"
            prop.onChange handler
            prop.children [
                for item in items do
                    Html.option [
                        prop.style [ style.color CitColors.darkBlue]
                        prop.value item
                        prop.text item
                    ]
                ]
            ]

    static member LabelWithSelect (name: string) items handler =
        Html.div [
            prop.style [ style.display.flex; style.justifyContent.spaceBetween; style.alignItems.center; style.marginBottom 20 ]
            prop.children [
                Html.b name
                StyledComponents.Select items handler
            ]
        ]

    static member Footer (children: ReactElement list) =
        Html.div [
            prop.style [
                style.backgroundColor "#102035"
                style.height 300
                style.color "white"
                style.display.flex
                style.justifyContent.spaceBetween
                style.alignItems.center
                style.position.relative
            ]
            prop.children children
        ]

type Components =

    [<ReactComponent>]
    static member Demo () =

        //let (props, setProps) = React.useState(initProps)


        StyledComponents.Container [
            Html.div [
                prop.style [ style.display.flex; style.flexWrap.wrap; style.flexDirection.column ]
                prop.children [
                    Html.div [
                        StyledComponents.Description
                            "Feliz.ReactSpeedometer"
                            "react-d3-speedometer"
                            { Name = "nuget"; Link = "https://www.nuget.org/packages/Feliz.ReactSpeedometer/" }
                            { Name = "npm"; Link = "https://www.npmjs.com/package/react-d3-speedometer" }

                        StyledComponents.HeadingWithContent
                            "Demo"
                            (Html.div [
                                prop.style [ style.display.flex; style.justifyContent.center; style.alignItems.center ]
                                prop.children [
                                    ReactSpeedometer.create [
                                        ReactSpeedometer.Value 100
                                        ReactSpeedometer.NeedleTransition EaseBackOut
                                        ReactSpeedometer.Width 500
                                        ReactSpeedometer.NeedleHeightRatio 0.7
                                        ReactSpeedometer.RingWidth 100
                                        ReactSpeedometer.NeedleTransitionDuration 1500
                                        ReactSpeedometer.Segments 5
                                        ReactSpeedometer.NeedleColor CitColors.darkBlue
                                        ReactSpeedometer.SegmentColors [| CitColors.yellow; CitColors.orange; CitColors.red; CitColors.green; CitColors.lightBlue  |]
                                    ]
                                ]
                            ])

                        StyledComponents.HeadingWithContent
                            "Installation"
                            (StyledComponents.CodeBlock """
cd ./project
femto install Feliz.ReactSpeedometer""" )

                        StyledComponents.HeadingWithContent
                            "Sample Code"
                            (StyledComponents.CodeBlock """
open Feliz.ReactSpeedometer

ReactSpeedometer.create [
    ReactSpeedometer.Value 100
    ReactSpeedometer.NeedleTransition EaseBackOut
    ReactSpeedometer.Width 500
    ReactSpeedometer.NeedleHeightRatio 0.7
    ReactSpeedometer.RingWidth 100
    ReactSpeedometer.NeedleTransitionDuration 1500
    ReactSpeedometer.Segments 5
    ReactSpeedometer.NeedleColor "#102035"
    ReactSpeedometer.SegmentColors [|
        "#fec903"
        "#e97305"
        "#e1053a"
        "#8cbf41"
        "#40a8b7"
    |]
]""" )
                    ]
                ]
            ]
        ]

    [<ReactComponent>]
    static member Documentation () =
        Html.div [
            StyledComponents.Navbar()
            Components.Demo()
        ]

