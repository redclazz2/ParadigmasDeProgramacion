--Ejercicio #2
--Definición de la función sumatoria con los tipos de datos de entrada y de salida
sumatoria :: Integer -> Integer -> Integer 
sumatoria a b 
    |b == a = a 
    |otherwise = b + sumatoria a (b-1)

{-
El algoritmo funciona de la siguiente manera: [a,b]
resultado = b + (b-1) + (b-2) + ... + (b-n), siempre que b>a
el caso para la finalización es si b == a, en cuyo caso se retorna a que es el
último numero a sumar
-}    

--llamada a main para invocar a sumatoria con los valores a = 5, b = 10
main :: IO ()
main = print (sumatoria 5 10)