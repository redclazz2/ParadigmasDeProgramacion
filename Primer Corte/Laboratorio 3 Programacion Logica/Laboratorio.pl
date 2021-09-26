/* Laboratorio Programacion Logica*/
/* Hechos */
hombre(sebastian).
hombre(diego).
hombre(efrain).
hombre(armando).
hombre(javier).
hombre(simon).
hombre(tomas).

mujer(johanna).
mujer(carol).
mujer(martha).
mujer(cecilia).
mujer(chela).
mujer(maria_j).

/* Reglas */
es_papa_de(diego,sebastian). %Padre, Hijo
es_papa_de(armando,diego).
es_papa_de(efrain,johanna).
es_papa_de(efrain,carol).
es_papa_de(armando,martha).
es_papa_de(javier,simon).
es_papa_de(javier,tomas).

es_mama_de(johanna,sebastian). %Madre, Hijo
es_mama_de(chela,johanna).
es_mama_de(chela,carol).
es_mama_de(cecilia,diego).
es_mama_de(cecilia,martha).
es_mama_de(martha,tomas).
es_mama_de(martha,simon).
es_mama_de(carol,maria_j).

/* Primera Linea de Sangre*/
%Hij@, busca los padres del hij@ especificad@, cada regla depende del sexo de la persona
es_hijo_de(HIJO,PADRE,MADRE) :- hombre(HIJO) , es_mama_de(MADRE,HIJO) , es_papa_de(PADRE,HIJO). %(X,Y,Z) donde Y Z son padres de X
es_hija_de(HIJA,PADRE,MADRE) :- mujer(HIJA) , es_mama_de(MADRE,HIJA) , es_papa_de(PADRE,HIJA). 

%Abuel@s, busca los nietos de la persona espeficiada, cada regla depende del sexo de la persona
es_abuelo_de(ABUELO,NIETO) :- hombre(ABUELO), es_papa_de(ABUELO,HIJO),(es_papa_de(HIJO,NIETO);es_mama_de(HIJO,NIETO)). %(X,Y) donde X es abuel@ de Y
es_abuela_de(ABUELA,NIETO) :- mujer(ABUELA), es_mama_de(ABUELA,HIJO),(es_papa_de(HIJO,NIETO);es_mama_de(HIJO,NIETO)). 

%Niet@s, busca los abuelos de la persona especificada, cada regla depende del sexo de la persona
%(X,Y,Z,W,F), donde X es el niet@, Y Z los abuelos paternos, W F abuelos maternos
es_nieto_de(NIETO,ABUELO_P,ABUELA_P,ABUELO_M,ABUELA_M) :- hombre(NIETO), es_hijo_de(NIETO,PADRE,MADRE),(es_hijo_de(PADRE,ABUELO_P,ABUELA_P), es_hija_de(MADRE,ABUELO_M,ABUELA_M)).
es_nieta_de(NIETO,ABUELO_P,ABUELA_P,ABUELO_M,ABUELA_M) :- mujer(NIETO), es_hija_de(NIETO,PADRE,MADRE),(es_hijo_de(PADRE,ABUELO_P,ABUELA_P), es_hija_de(MADRE,ABUELO_M,ABUELA_M)).

%Herman@s, busca l@s herman@s de la persona especificada, cada regla depende del sexo de la persona
%(X,Y), donde X es la persona de la que se quieren saber los hermanos, Y los resultados de la busqueda
es_hermano_de(CONSULTA,HERMANOS) :- hombre(CONSULTA), es_hijo_de(CONSULTA,PADRE,MADRE),(es_papa_de(PADRE,HERMANOS),es_mama_de(MADRE,HERMANOS)), CONSULTA \= HERMANOS.
es_hermana_de(CONSULTA,HERMANOS) :- mujer(CONSULTA), es_hija_de(CONSULTA,PADRE,MADRE),(es_papa_de(PADRE,HERMANOS),es_mama_de(MADRE,HERMANOS)), CONSULTA \= HERMANOS.


/* Segunda Linea de Sangre 
De acuerdo a lo especificado en la clase, los puntos i y j (ancestros y descendientes) se saltan.
*/

%Ti@s, busca de quien es tio la persona especificada, cada regla depende del sexo de la persona
es_tio_de(TIO,RESULTADOS):- es_hermano_de(TIO,HERMANOS), (es_papa_de(HERMANOS,RESULTADOS);es_mama_de(HERMANOS,RESULTADOS)). %(X,Y), donde x es el ti@ a consultar, Y los resultados.
es_tia_de(TIO,RESULTADOS):- es_hermana_de(TIO,HERMANOS), (es_papa_de(HERMANOS,RESULTADOS);es_mama_de(HERMANOS,RESULTADOS)).

%Sobrin@s, busca quienes son los tios de la persona indicada, cada regla depende del sexo de la persona.
es_sobrino_de(CONSULTA,TIOS_P,TIOS_M) :- es_hijo_de(CONSULTA,PADRE,MADRE),(es_hermano_de(PADRE,TIOS_P),es_hermana_de(MADRE,TIOS_M)).
es_sobrina_de(CONSULTA,TIOS_P,TIOS_M) :- es_hija_de(CONSULTA,PADRE,MADRE),(es_hermano_de(PADRE,TIOS_P),es_hermana_de(MADRE,TIOS_M)).

%Prim@s, se busca quienes son los primos de la persona especificada, cada regla depende del sexo de la persona.
%(X,Y,Z), donde x es la persona a la que se le van a encontrar los primos, Y los primos por parte del papa, Z los primos por parte de la mama
es_primo_de(CONSULTA,PRIMOS_P,PRIMOS_M) :-  
    es_hijo_de(CONSULTA,PADRE,MADRE), (es_hermano_de(PADRE,HERMANOS_P),(es_papa_de(HERMANOS_P,PRIMOS_P);es_mama_de(HERMANOS_P,PRIMOS_P))) , (es_hermana_de(MADRE,HERMANOS_M),(es_papa_de(HERMANOS_M,PRIMOS_M);es_mama_de(HERMANOS_M,PRIMOS_M))).
es_prima_de(CONSULTA,PRIMOS_P,PRIMOS_M) :-  
    es_hija_de(CONSULTA,PADRE,MADRE), (es_hermano_de(PADRE,HERMANOS_P),(es_papa_de(HERMANOS_P,PRIMOS_P);es_mama_de(HERMANOS_P,PRIMOS_P))) , (es_hermana_de(MADRE,HERMANOS_M),(es_papa_de(HERMANOS_M,PRIMOS_M);es_mama_de(HERMANOS_M,PRIMOS_M))).


/* ¿Cómo establecer las siguientes relaciones? */
%Espos@, busca quien es el conyuge de la persona indicada, se asume que mientras tengan un hijo en comun, estan casados. Cada regla depende del sexo de la persona. 
es_esposo_de(ESPOSO,CONYUGE) :- es_papa_de(ESPOSO,HIJO), es_mama_de(CONYUGE,HIJO).
es_esposa_de(ESPOSA,CONYUGE) :- es_mama_de(ESPOSA,HIJO), es_papa_de(CONYUGE,HIJO).

%Cunad@, busca de quien es cunad@ la persona especificada, la relga depende del sexo de la persona.
es_cunado_de(CUNADO,RESULTADO) :- es_esposo_de(CUNADO,CONYUGE), es_hermana_de(CONYUGE,RESULTADO).
es_cunada_de(CUNADO,RESULTADO) :- es_esposa_de(CUNADO,CONYUGE), es_hermano_de(CONYUGE,RESULTADO).

%Suegr@s, busca de quien es suegr@ la persona especificada, la relga depende del sexo de la persona.
es_suegro_de(SUEGRO,RESULTADO) :- es_papa_de(SUEGRO,HIJO), (es_esposo_de(HIJO,RESULTADO);es_esposa_de(HIJO,RESULTADO)).
es_suegra_de(SUEGRO,RESULTADO) :- es_mama_de(SUEGRO,HIJO), (es_esposo_de(HIJO,RESULTADO);es_esposa_de(HIJO,RESULTADO)).

%Ti@s politicos, busca de quien es ti@ politic@ la persona especificada, la relga depende del sexo de la persona.
es_tio_politico_de(TIOP,RESULTADO) :- es_esposo_de(TIOP,CONYUGE), es_hermana_de(CONYUGE,HERMANO), (es_papa_de(HERMANO,RESULTADO);es_mama_de(HERMANO,RESULTADO)).
es_tia_politica_de(TIOP,RESULTADO) :- es_esposa_de(TIOP,CONYUGE), es_hermano_de(CONYUGE,HERMANO), (es_papa_de(HERMANO,RESULTADO);es_mama_de(HERMANO,RESULTADO)).