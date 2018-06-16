module PropertyTests1RefactoredFsCheck

open FsCheck.NUnit

let add x y = 
    x + y 

[<Property(QuietOnSuccess = true, Verbose = true)>]
let ``Commutative property`` (x, y) = 
    let result1 = add x y
    let result2 = add y x
    result1 = result2

[<Property(QuietOnSuccess = true)>]
let ``Adding 1 Twice Is Adding 2 Once Property`` x = 
    let result1 = x |> add 1 |> add 1
    let result2 = x |> add 2 
    result1 = result2

[<Property(QuietOnSuccess = true)>]
let ``Identity property`` x = 
    let result1 = x |> add 0
    result1 = x
