module Feliz

open Feliz
open Fable.Core.JsInterop

let reactSpeedometer: obj = importDefault "react-d3-speedometer"

type Transition =
    | EaseLinear
    | EaseQuadIn
    | EaseQuadOut
    | EaseQuadInOut
    | EaseCubicIn
    | EaseCubicOut
    | EaseCubicInOut
    | EasePolyIn
    | EasePolyOut
    | EasePolyInOut
    | EaseSinIn
    | EaseSinOut
    | EaseSinInOut
    | EaseExpIn
    | EaseExpOut
    | EaseExpInOut
    | EaseCircleIn
    | EaseCircleOut
    | EaseCircleInOut
    | EaseBounceIn
    | EaseBounceOut
    | EaseBounceInOut
    | EaseBackIn
    | EaseBackOut
    | EaseBackInOut
    | EaseElasticIn
    | EaseElasticOut
    | EaseElasticInOut
    | EaseElastic
        with static member toJSValue = function
            | EaseLinear -> "easeLinear"
            | EaseQuadIn -> "easeQuadIn"
            | EaseQuadOut -> "easeQuadOut"
            | EaseQuadInOut -> "easeQuadInOut"
            | EaseCubicIn -> "easeCubicIn"
            | EaseCubicOut -> "easeCubicOut"
            | EaseCubicInOut -> "easeCubicInOut"
            | EasePolyIn -> "easePolyIn"
            | EasePolyOut -> "easePolyOut"
            | EasePolyInOut -> "easePolyInOut"
            | EaseSinIn -> "easeSinIn"
            | EaseSinOut -> "easeSinOut"
            | EaseSinInOut -> "easeSinInOut"
            | EaseExpIn -> "easeExpIn"
            | EaseExpOut -> "easeExpOut"
            | EaseExpInOut -> "easeExpInOut"
            | EaseCircleIn -> "easeCircleIn"
            | EaseCircleOut -> "easeCircleOut"
            | EaseCircleInOut -> "easeCircleInOut"
            | EaseBounceIn -> "easeBounceIn"
            | EaseBounceOut -> "easeBounceOut"
            | EaseBounceInOut -> "easeBounceInOut"
            | EaseBackIn -> "easeBackIn"
            | EaseBackOut -> "easeBackOut"
            | EaseBackInOut -> "easeBackInOut"
            | EaseElasticIn -> "easeElasticIn"
            | EaseElasticOut -> "easeElasticOut"
            | EaseElasticInOut -> "easeElasticInOut"
            | EaseElastic -> "easeElastic"

type CustomSegmentLabelPosition =
    | Outside
    | Inside
        with static member toJSValue = function
                | Outside -> "OUTSIDE"
                | Inside -> "INSIDE"

type CustomSegmentLabel =
    { Text: string
      Position: CustomSegmentLabelPosition
      FontSize: string
      Color: string }
        with static member toJSObj customLabel =
                {| text = customLabel.Text
                   position = customLabel.Position |> CustomSegmentLabelPosition.toJSValue
                   fontSize = customLabel.FontSize
                   color = customLabel.Color |}

type DimensionUnit =
    | EM
    | EX
    | PX
    | IN
    | CM
    | MM
    | PT
    | PC
        with static member toJSValue = function
                | EM -> "em"
                | EX -> "ex"
                | PX -> "px"
                | IN -> "in"
                | CM -> "cm"
                | MM -> "mm"
                | PT -> "pt"
                | PC -> "pc"

type ReactSpeedometer =

    static member inline Value (number: int) = "value" ==> number
    static member inline MinValue (number: int) = "minValue" ==> number
    static member inline MaxValue (number: int) = "maxValue" ==> number
    static member inline MaxSementLabels (number: int) = "maxSementLabels" ==> number
    static member inline Segments (number: int) = "segments" ==> number
    static member inline Width (number: int) = "width" ==> number
    static member inline Height (number: int) = "height" ==> number
    static member inline NeedleTransitionDuration (number: int) = "needleTransitionDuration" ==> number
    static member inline RingWidth (number: int) = "ringWidth" ==> number
    static member inline PaddingHorizontal (number: int) = "paddingHorizontal" ==> number
    static member inline PaddingVertical (number: int) = "paddingVertical" ==> number


    static member inline NeedleHeightRatio (number: float) =
        if (number > 0. && number < 1.) then "needleHeightRatio" ==> number

    static member inline CustomSegmentStops (ranges: int []) = "customSegmentStops" ==> ranges

    static member inline ForceRender (reRender: bool) = "forceRender" ==> reRender
    static member inline FluidWidth (isFluid: bool) = "fluidWidth" ==> isFluid

    static member inline NeedleColor (color: string) = "needleColor" ==> color
    static member inline StartColor (color: string) = "startColor" ==> color
    static member inline EndColor (color: string) = "endColor" ==> color
    static member inline SegmentColors (colors: string []) = "segmentColors" ==> colors
    static member inline TextColor (colors: string []) = "textColor" ==> colors

    static member inline LabelFontSize (size: string) = "labelFontSize" ==> size
    static member inline ValueTextFontSize (size: string) = "valueTextFontSize" ==> size

    static member inline DimensionUnit (dimensionUnit: DimensionUnit) = "dimensionUnit" ==> (dimensionUnit |> DimensionUnit.toJSValue)
    static member inline NeedleTransition (transition: Transition) = "needleTransition" ==> (transition |> Transition.toJSValue)

    static member inline CustomSegmentLabels (customSegmentLabels: CustomSegmentLabel []) =
        let jsCustomSegmentLabels = customSegmentLabels |> Array.map CustomSegmentLabel.toJSObj
        "customSegmentLabels" ==> jsCustomSegmentLabels

    static member inline create props = Interop.reactApi.createElement (reactSpeedometer, createObj !!props)
