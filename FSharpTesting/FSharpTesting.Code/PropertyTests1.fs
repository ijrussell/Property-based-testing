module PropertyTests1

open NUnit.Framework
open FsUnit

let rand = System.Random()
let randInt() = rand.Next()

let add x y =
    x + y

[<Test>]
let ``When I add two numbers (100 times), I expect their sum to be correct``() =
    for _ in [1..100] do
        let x = randInt()
        let y = randInt()
        let expected = x + y // Don't do this!
        let actual = add x y 
        expected |> should equal actual



         
[<Test>]
let ``When I add two numbers, the result should not depend on parameter order``() =
    for _ in [1..100] do
        let x = randInt()
        let y = randInt()
        let expected = add x y
        let actual = add y x
        expected |> should equal actual

[<Test>]
let ``Adding 1 twice is the same as adding 2``()=
    for _ in [1..100] do
        let x = randInt()
        let result1 = x |> add 1 |> add 1
        let result2 = x |> add 2 
        result1 |> should equal result2

[<Test>]
let ``Adding zero is the same as doing nothing``()=
    for _ in [1..100] do
        let x = randInt()
        let result1 = x |> add 0
        let result2 = x  
        result1 |> should equal result2
