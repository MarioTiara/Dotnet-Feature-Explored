if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (UserName, FirstName, LastName,EmailAddress, [Password],[Role])
	values ('TimeCorey','Tim', 'Corey','Corey@gmail.com', '123deqa', 'Adminstrator'),
	('StormSue','Sue', 'Storm','Sue.Storm@gmail.com','122asd','Standard'),
	('JohnSMith','John', 'Smith','JohnSmith@gmail.com','234dft','Adminstrator'),
	('JonesMary','Mary', 'Jones','MaryJones@gmail.com','azsa21','Standard');

	insert into dbo.Movie (Title, Description, Rating)
	values('Eternals', 'The saga of the Eternals, a race of immortal beings who lived on Earth and shaped its history and civilizations.',6.8),
	('Dune', 'Feature adaptation of Frank Herberts science fiction novel, about the son of a noble family entrusted with the protection of the most valuable asset and most vital element in the galaxy.',8.8),
	('The Harder They Fall', 'When an outlaw discovers his enemy is being released from prison, he reunites his gang to seek revenge in this Western.',8.8),
	('Red Notic', 'An Interpol agent tracks the worlds most wanted art thief.',6.4),
	('No Time to Die', 'James Bond has left active service. His peace is short-lived when Felix Leiter, an old friend from the CIA, turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology',7.4);
end
GO
