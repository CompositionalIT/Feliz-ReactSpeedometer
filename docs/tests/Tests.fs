module Tests

open Fable.Mocha

let add x y = x + y

let appTests = testList "App tests" [
    testCase "add works" <| fun _ ->
        let result = add 2 4
        Expect.equal result 6 "Result must be 6"
]

let allTests = testList "All" [
    appTests
]

[<EntryPoint>]
let main (args: string[]) = Mocha.runTests allTests
