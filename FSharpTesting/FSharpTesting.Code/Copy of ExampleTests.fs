module ``Example Tests``

open NUnit.Framework
open FsUnit

//let rand = System.Random()
//let randInt() = rand.Next()

let add x y =
    x + y

[<Test>]
let ``Add 2 and 2 equals 4`` () =
    let expected = 4
    let actual = add 2 2
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Add 1 and 3 equals 4`` () =
    let actual = add 1 3
    actual |> should equal 4

[<Test>]
let ``Add 1 and 41 equals 42`` () =
    add 1 41 |> should equal 42

[<Test>]
let ``Add 1 and 1 does not equal 3`` () =
    add 1 1 |> should not' (equal 3)





//let add x y =
//    match (x, y) with
//    | 2, 2 -> 4
//    | 1, 3 -> 4
//    | 1, 41 -> 42
//    | _, _ -> 0