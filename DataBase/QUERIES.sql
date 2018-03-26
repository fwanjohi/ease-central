
--HERE IS THE SOLUTION FOR THE QUESTIONS
--IN REAL LIFE, i WOULD HAVE USED A STORED PROCEDURE FOR EACH TO AVOID QUERY INJECTION

--I have also supplied sample data in the other file.

--Display people and their phone number
SELECT p.*,
	Pa.StreetAddress, 
	Pa.City, 
	Pa.State, 
	Pa.Zip FROM Person P
JOIN PersonAddress PA on PA.PersonId = p.PersonId 

--Display people and their phone numbers
SELECT p.*,
	Ph.PhoneNumber FROM Person P
JOIN PersonPhone Ph on Ph.PersonId = p.PersonId 


--Display people and their addresses only if they are in the state of California
SELECT p.*,
	Pa.StreetAddress, 
	Pa.City, 
	Pa.State, 
	Pa.Zip FROM Person P
JOIN PersonAddress PA on PA.PersonId = p.PersonId 
where Pa.State = 'CA' -- THIS WOULD HAVE BEEN PASSED AS A PARAMETER IN AN SP, SO THAT IT CAN BE REUSED.

--Show how many people have addresses in each state
SELECT STATE, COUNT(*) as NumberOfPeople FROM PersonAddress
GROUP BY STATE ORDER BY COUNT(*)

--Show the % of people that have multiple addresses

declare @PeopleCount INT
SELECT @PeopleCount = Count(PersonId) from Person

declare @multiHomeCount INT;
SELECT @multiHomeCount = Count(PersonId)
from 
(
	select DISTINCT PERSONID, COUNT(PERSONID) HomeCount FROM PersonAddress
	GROUP BY PERSONID
	HAVING  COUNT(PERSONID) > 1

) multi;

select @PeopleCount AS TotalPeopleCount, @multiHomeCount as MultiHomeCount,  CAST( CAST(@multiHomeCount AS  decimal(6,4))  / CAST(@PeopleCount AS decimal(6,4)) * 100 AS DECIMAL (6,4)) MultiHomePercentage

