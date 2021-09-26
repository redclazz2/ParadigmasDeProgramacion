--Ejercicio 5
--Para este ejercicio se debe definir que la función requiere un valor Float y devuelve Float
calcularPi :: Float -> Float
calcularPi n = 4 * sum[((-1)**x)/((2*x)+1) | x <- [0..n]]


main :: IO ()
main = do
    print "Ingrese el valor de precisión para calcular PI: "
    cadena <- getLine 
    let numero = read cadena:: Float
    print(calcularPi numero)

{-
En este caso se añaden 3 líneas de código, la primera pregunta al usuario el número de precision
La segunda lee la entrada del usuario y devuelve una cadena por medio de getLine
La tercera se encarga de convertir el tipo cadena a Flotante por medio de read :: Float
-}
