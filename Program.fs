// For more information see https://aka.ms/fsharp-console-apps
open System

module PigLatin =
    let toPigLatin (word: string) =
        let isVowel (c: char) =
            match c with
            | 'a' | 'e' | 'i' | 'o' | 'u'
            | 'A' | 'E' | 'I' | 'O' | 'U' -> true
            |_ -> false
        
        if isVowel word.[0] then
            word + "yay"
        else
            word.[1..] + string word.[0] + "ay"

[<EntryPoint>]
let main args =
    let rec getInput () =
        printfn "Enter a word or 'quit' to exit:"
        let input = Console.ReadLine()
        match input.ToLower() with
        | "quit" -> []
        | word -> word :: getInput ()

    let rec processInput words =
        match words with
        | [] -> ()
        | head :: tail ->
            let newWord = PigLatin.toPigLatin head
            printfn "%s in Pig Latin is: %s" head newWord
            processInput tail

    printfn "Welcome to the Pig Latin Converter!"

    let inputWords = getInput ()
    if List.isEmpty inputWords then
        printfn "No words provided. Exiting."
    else
        processInput inputWords

    0
