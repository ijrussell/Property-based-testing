module PropertyTests1Refactored

open NUnit.Framework
open FsUnit

let rand = System.Random()
let randInt() = rand.Next()

let add x y = x + y 

let propertyCheck property = 
    // property has type: int -> int -> bool
    for _ in [1..100] do
        let x = randInt()
        let y = randInt()
        let result = property x y
        result |> should be True

let commutativeProperty x y = 
    let result1 = add x y
    let result2 = add y x
    result1 = result2

let adding1TwiceIsAdding2OnceProperty x _ = 
    let result1 = x |> add 1 |> add 1
    let result2 = x |> add 2 
    result1 = result2

let identityProperty x _ = 
    let result1 = x |> add 0
    result1 = x

[<Test>]
let ``When I add two numbers, the result should not depend on parameter order``()=
    propertyCheck commutativeProperty 

[<Test>]
let ``Adding 1 twice is the same as adding 2``()=
    propertyCheck adding1TwiceIsAdding2OnceProperty 

[<Test>]
let ``Adding zero is the same as doing nothing``()=
    propertyCheck identityProperty 