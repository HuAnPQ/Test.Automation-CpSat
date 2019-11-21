Feature: Es una prueba para ver la edicion de Wikipedia

@mytag
Scenario: Edicion en Wiki
	Given Estoy en la pagina de Wikipedia Produbanco
	And Haga Click En Editar
	Then El Titulo de la pagina de edicion debaria Incluir a la palabra "Produbanco"
