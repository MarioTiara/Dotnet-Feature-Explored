if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName,EmailAddress, [Password])
	values ('Tim', 'Corey','Corey@gmail.com', '123deqa'),
	('Sue', 'Storm','Sue.Storm@gmail.com','122asd'),
	('John', 'Smith','JohnSmith@gmail.com','234dft'),
	('Mary', 'Jones','MaryJones@gmail.com','azsa21');
end
