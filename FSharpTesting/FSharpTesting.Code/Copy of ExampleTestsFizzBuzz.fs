module ExampleTestsFizzBuzz

open FsUnit
open NUnit.Framework

let fizzBuzz n =
    match (n%3, n%5) with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _, _ -> n.ToString()

[<Test>]
let ``Divisible by 3 and 5 returns FizzBuzz`` ([<Values(15,30)>] n) =
    let actual = fizzBuzz n
    actual |> should equal "FizzBuzz"

[<Test>]
let ``Divisible by 3 returns Fizz`` ([<Values(3,6,9,12)>] n) =
    let actual = fizzBuzz n
    actual |> should equal "Fizz"
