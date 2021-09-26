--Ejercicio 4
--Por medio de calcularPi se encuentra el aproximado, utilizando list comprehesion que representa a la formula dada en el enunciado
calcularPi n = 4 * sum[((-1)**x)/((2*x)+1) | x <- [0..n]]

--Llamada a main para invocar a calcularPi
main = print(calcularPi 300)