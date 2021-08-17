--Ejercicio #1
--Se definen los tipos de datos que la función va a tomar y el que va a retornar
calculadora :: Float -> Float -> Float -> [Float]
--Calculo de las raices de la función cuadrática sin tener en cuenta los resultados imaginarios
calculadora a b c 
    | d >= 0 = [(-b+d)/(2*a),(-b-d)/(2*a)]
    | otherwise = error "Raices Imaginarias"
    where d = sqrt((b^2)-(4*a*c))

--Llamada a Main para invocar 'calculadora' con los números a = 6, b = 7, c = 2
main :: IO ()
main = print (calculadora 11 45 7)