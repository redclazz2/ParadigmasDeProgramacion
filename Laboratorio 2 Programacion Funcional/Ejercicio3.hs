--Ejercicio #3
--Por medio de esta función se eligen los factores del número brindado
funcionFactores n = [i | i <- [1..n-1], n `mod` i == 0]

--Por medio de esta función se comprueba si la suma de los factores es igual al número para determinar si es perfecto.
funcionPerfecto :: Integer -> String
funcionPerfecto n
    | sum(funcionFactores n) == n = "Perfecto"
    | otherwise = "No es perfecto"

--Lamada a main para invocar a funcionPerfecto donde a = 29
main :: IO ()
main = print(funcionPerfecto 33550336)