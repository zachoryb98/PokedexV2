echo off

rem batch file to run a script to create a db
rem 9/5/2019

sqlcmd -S localhost -E -i PokedexDB.sql
rem sqlcmd -S localhost\mssqlserver -E -i PokedexDB.sql
rem sqlcmd -S localhost\sqlexpress -E -i PokedexDB.sql
rem Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

ECHO .
ECHO if no error messages appear DB was created
PAUSE