# PROJECT NAME - TextABCSort

## User Story

* as a text analyser
* I want to reorder and reformat a paragrap of text as follows:
    *	words should be reordered Alphabetically -  (Zerbra Abba) becomes (Abba Zebra)
    *	words should **THEN** be ordered from upper case to lower case. Note point 1 takes preference. (aBba Abba) becomes (Abba aBba)
    * remove all (.,;') chars. (aBba, Abba) becomes (Abba aBba)
    *	Do not remove duplicate words
* so that I can easily read though the words alphabetically and easily see all the variants of different case

## Notes
* The user story test is most important. Other notes are of secondary importance.
* if needed additional unit tests may be added
* insure you are happy with the project structure
* take into account we may want to swap console logger with event logger in future
* although this is a simple test, please complete the code as you would for a production release

## Running the application
I have put together a light weight console app to run the sort, this can be found in 
TextABCSort\TextSorter\Program.cs

## Tests
The tests are located in TextABCSort\Core.UnitTests\SortingLogic\SortingLogicTests.cs
The logger tests are a future TODO

## Architecture
I've implemented a factory pattern for the sorting logic, and an adaptor pattern for the logging. 
