namespace Program

open System

module pipe =
    let square x =
        x * x
    let pipe f =
        f |> square  
     
module descrimination =
    type Shape = 
    | Rectangle of width : float * length : float
    | Circle of radius : float
    | Prism of width : float * float * length : float
    
    let rec area myShape =
         match myShape with
          | Circle (radius) -> Math.PI * radius * radius
          | Rectangle (l, w) -> l * w
   
module expressions = 
    let squares =
     seq {
        for i in 1..5 do
            yield i * i
     }
    let cubes =
      seq {
        for i in 1..3 -> i * i * i
    }
    let squaresAndCubes =
      seq {
        yield! squares
        yield! cubes
    }    
    printfn $"{squaresAndCubes}" 

        
  