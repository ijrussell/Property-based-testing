module ListTests

open FsUnit
open NUnit.Framework

let original = [1; 6; 2; 9; 3; 2]

let sort input =
    input 
    |> List.sort

[<Test>]
let ``Length is the same``() =
    let sorted = original |> sort
    sorted.Length |> should equal original.Length

[<Test>]
let ``Contains then same chars``() =
    let a = original |> List.countBy (fun x -> x) |> Set.ofList
    let b = original |> sort |> List.countBy (fun x -> x) |> Set.ofList
    let diff = Set.difference a b
    diff |> should equal []

[<Test>]
let ``Each pair is sorted correctlt``() =
    let x = original |> sort |> List.pairwise |> List.fold (fun acc elem -> acc && fst elem <= snd elem) true
    x |> should equal true