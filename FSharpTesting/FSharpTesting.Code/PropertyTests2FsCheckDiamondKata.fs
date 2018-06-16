module PropertyTests2FsCheckDiamondKata

//// A

//// -A-
//// B-B
//// -A-

//// --A--
//// -B-B-
//// C---C
//// -B-B-
//// --A--

//// ---A---
//// --B-B--
//// -C---C-
//// D-----D
//// -C---C-
//// --B-B--
//// ---A---

//// Example properties :
////  First and last rows contain A
////  Vertical symmetry
////  Letters in correct order
////  As wide as it's high
////  Inner space
////  Bottom triangle
////  Horizontal symmetry

//open FsCheck.NUnit
//open FsUnit
//open FsCheck
//open System

//let make letter =
//    let makeLine width letter =
//        match letter with
//        | 'A' ->
//            let padding = String(' ', (width - 1) / 2)
//            sprintf "%s%c%s" padding letter padding
//        | _ -> String(letter, width)
 
//    let letters = ['A' .. letter]
//    let letters = letters @ (letters |> List.rev |> List.tail)
 
//    let width = letters.Length
 
//    letters
//    |> List.map (makeLine width)
//    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)

//type Letters =
//    static member Char() = Gen.elements ['A' .. 'Z'] |> Arb.fromGen
 
//type DiamondPropertyAttribute() =
//    inherit PropertyAttribute(
//        Arbitrary = [| typeof<Letters> |],
//        QuietOnSuccess = true)
 
//[<DiamondProperty>]
//let ``Diamond is non-empty`` (letter : char) =
//    let actual = make letter
//    actual |> should not' (be EmptyString)

//// First and last rows contain A
//let split (x : string) =
//    x.Split([| Environment.NewLine |], StringSplitOptions.None)
 
//let trim (x : string) = x.Trim()
 
//[<DiamondProperty>]
//let ``First row contains A`` (letter : char) =
//    let actual = make letter
//    let rows = split actual
//    rows |> Seq.head |> trim = "A"
 
//[<DiamondProperty>]
//let ``Last row contains A`` (letter : char) =
//    let actual = make letter
//    let rows = split actual
//    rows |> Seq.last |> trim = "A"
//// let make = "    A "

//// Vertical symmetry
//let leadingSpaces (x : string) =
//    let indexOfNonSpace = x.IndexOfAny [| 'A' .. 'Z' |]
//    x.Substring(0, indexOfNonSpace)
 
//let trailingSpaces (x : string) =
//    let lastIndexOfNonSpace = x.LastIndexOfAny [| 'A' .. 'Z' |]
//    x.Substring(lastIndexOfNonSpace + 1)
 
//[<DiamondProperty>]
//let ``All rows must have a symmetric contour`` (letter : char) =
//    let actual = make letter
//    let rows = split actual
//    rows |> Array.forall (fun r -> (leadingSpaces r) = (trailingSpaces r))
////// let make = "    A    "

//// Letters in correct order
//[<DiamondProperty>]
//let ``Rows must contain the correct letters, in the correct order``
//    (letter : char) =
    
//    let actual = make letter
 
//    let letters = ['A' .. letter]
//    let expectedLetters =
//        letters @ (letters |> List.rev |> List.tail) |> List.toArray
//    let rows = split actual
//    expectedLetters = (rows |> Array.map trim |> Array.map Seq.head)
//////let make letter =
//////    let letters = ['A' .. letter]
//////    let letters = letters @ (letters |> List.rev |> List.tail)
//////    letters
//////    |> List.map string 
//////    |> List.reduce (fun x y -> sprintf "%s%s%s" x System.Environment.NewLine y)

//// As wide as it's high
//[<DiamondProperty>]
//let ``Diamond is as wide as it's high`` (letter : char) =
//    let actual = make letter
 
//    let rows = split actual
//    let expected = rows.Length
//    rows |> Array.forall (fun x -> x.Length = expected)
//////let make letter =
//////    let makeLine width letter =
//////        match letter with
//////        | 'A' ->
//////            let padding = String(' ', (width - 1) / 2)
//////            sprintf "%s%c%s" padding letter padding
//////        | _ -> String(letter, width)
 
//////    let letters = ['A' .. letter]
//////    let letters = letters @ (letters |> List.rev |> List.tail)
 
//////    let width = letters.Length
 
//////    letters
//////    |> List.map (makeLine width)
//////    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)

////// Inner space
//[<DiamondProperty>]
//let ``All rows except top and bottom have two identical letters``
//    (letter : char) =
 
//    let actual = make letter
 
//    let isTwoIdenticalLetters x =
//        let hasIdenticalLetters = x |> Seq.distinct |> Seq.length = 1
//        let hasTwoLetters = x |> Seq.length = 2
//        hasIdenticalLetters && hasTwoLetters
//    let rows = split actual
//    rows
//    |> Array.filter (fun x -> not (x.Contains("A")))
//    |> Array.map (fun x -> x.Replace(" ", ""))
//    |> Array.forall isTwoIdenticalLetters
//////let make letter =
//////    let makeLine width letter =
//////        match letter with
//////        | 'A' ->
//////            let padding = String(' ', (width - 1) / 2)
//////            sprintf "%s%c%s" padding letter padding
//////        | _ -> 
//////            let innerSpace = String(' ', width - 2)
//////            sprintf "%c%s%c" letter innerSpace letter
 
//////    let letters = ['A' .. letter]
//////    let letters = letters @ (letters |> List.rev |> List.tail)
 
//////    let width = letters.Length
 
//////    letters
//////    |> List.map (makeLine width)
//////    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)

////// Bottom triangle
////[<DiamondProperty>]
////let ``Lower left space is a triangle`` (letter : char) =
////    let actual = make letter
 
////    let rows = split actual
////    let lowerLeftSpace =
////        rows
////        |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
////        |> Seq.map leadingSpaces
////    let spaceCounts = lowerLeftSpace |> Seq.map (fun x -> x.Length)
////    let expected = Seq.initInfinite id
////    spaceCounts
////    |> Seq.zip expected
////    |> Seq.forall (fun (x, y) -> x = y)
//////let make letter =
//////    let makeLine width (letter, letterIndex) =
//////        match letter with
//////        | 'A' ->
//////            let padding = String(' ', (width - 1) / 2)
//////            sprintf "%s%c%s" padding letter padding
//////        | _ -> 
//////            let innerSpaceWidth = letterIndex * 2 - 1
//////            let padding = String(' ', (width - 2 - innerSpaceWidth) / 2)
//////            let innerSpace = String(' ', innerSpaceWidth)
//////            sprintf "%s%c%s%c%s" padding letter innerSpace letter padding
 
//////    let indexedLetters =
//////        ['A' .. letter] |> Seq.mapi (fun i l -> l, i) |> Seq.toList
//////    let indexedLetters = 
//////        (   indexedLetters
//////            |> List.map (fun (l, _) -> l, 1)
//////            |> List.rev
//////            |> List.tail
//////            |> List.rev)
//////        @ (indexedLetters |> List.rev)
 
//////    let width = indexedLetters.Length
 
//////    indexedLetters
//////    |> List.map (makeLine width)
//////    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)

////// Horizontal symmetry
////[<DiamondProperty>]
////let ``Figure is symmetric around the horizontal axis`` (letter : char) =
////    let actual = make letter
 
////    let rows = split actual
////    let topRows =
////        rows
////        |> Seq.takeWhile (fun x -> not (x.Contains(string letter))) 
////        |> Seq.toList
////    let bottomRows =
////        rows
////        |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
////        |> Seq.skip 1
////        |> Seq.toList
////        |> List.rev
////    topRows = bottomRows
//////let make letter =
//////    let makeLine width (letter, letterIndex) =
//////        match letter with
//////        | 'A' ->
//////            let padding = String(' ', (width - 1) / 2)
//////            sprintf "%s%c%s" padding letter padding
//////        | _ -> 
//////            let innerSpaceWidth = letterIndex * 2 - 1
//////            let padding = String(' ', (width - 2 - innerSpaceWidth) / 2)
//////            let innerSpace = String(' ', innerSpaceWidth)
//////            sprintf "%s%c%s%c%s" padding letter innerSpace letter padding
 
//////    let indexedLetters =
//////        ['A' .. letter] |> Seq.mapi (fun i l -> l, i) |> Seq.toList
//////    let indexedLetters = 
//////        indexedLetters @ (indexedLetters |> List.rev |> List.tail)
 
//////    let width = indexedLetters.Length
    
//////    indexedLetters
//////    |> List.map (makeLine width)
//////    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)