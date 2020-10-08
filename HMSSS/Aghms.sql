Create table DrSalary(D_ID int identity(001 , 1) not Null,

   Dr_Name varchar(50) Null,
   Dr_Ph# varchar(50) Null,
   Dr_Address varchar(50) Null,
   Gender varchar(50) Null,
   Dr_Email varchar(50) Null,
   Dr_Salary int Null,
   Joining_Date dateTime Null, 
   Primary Key (D_ID));
   insert into DrSalary (Dr_Name, Dr_Ph#,Dr_Address,Gender,Dr_Email,Dr_Salary,Joining_Date) Values ('Ramesh Kumar','0322222','Gulshan','Male','rkmalhi@gmail.com','30000','01/02/2008')
   insert into DrSalary (Dr_Name, Dr_Ph#,Dr_Address,Gender,Dr_Email,Dr_Salary,Joining_Date) Values ('Ali','0322222','Gulshan','Male','ali@gmail.com','30000','01/02/2008')
  
   select * from DrSalary;
   update DrSalary set Joining_Date = '02-01-2008' where D_ID= '1';
   ALTER TABLE DrSalary ADD  Dr_Lname varchar(50);

   Create table PPatient (D_ID int identity(001 , 1) not Null,
     P_Name Text Null,
    F_H_Name Text  Null,
    P_Ph# varchar(50) Null,
   P_Address varchar(50) Null,
   Gender Text Null,
   MR_No int Null,
   Room_No int Null,
   Room_type text Null,
   Admit_Date datetime Null, 
    Dicharge_Date datetime Null, 
   Primary Key (D_ID));
   ALTER TABLE PPatient ADD  P_age int;
   ALTER TABLE PPatient ADD  Bed_no int;
   ALTER TABLE PPatient ADD  Disease int;
   select * from PPatient;
  insert into PPatient (P_Name,F_H_Name,P_Ph#, P_Address, Gender,MR_No,Room_No, Room_type,Admit_Date) values ('Azam','Hasham','076547','Landi','Male','01','04','Normal','01-02-2018');
 
  create Table room( R_ID int identity (1,1) not null,
  Room_Type Text Null,
  Primary Key (R_ID));
  insert into room (Room_Type) values ('Normal');
  insert into room (Room_Type) values ('Medium');
  insert into room (Room_Type) values ('VIP');
 
  Alter Table room ADD cost int;
   
   
   update room set cost = '1000' where R_ID= '1';
 
  update room set cost = '2000' where R_ID= '2';
   update room set cost = '3000' where R_ID= '3';
  select * from room;

   insert into Nurse(Nursename,Ph#,N_Address,Gender,timein,timout) values ('Rose','032343','8:00','2:00');


  create Table Ward( W_ID int identity (1,1) not null,
   Wardname Text Null,
  
   Primary Key (W_ID));
   insert into Ward (Wardname) values ('Emergency');
   insert into Ward (Wardname) values ('General');


   
  
	ALTER TABLE Doctor ALTER COLUMN [Dr ID] text;
	insert into DrSalary 
	 insert into DRSpeciality(SID,Speciality,DRID) values ('01','Anhesthesiya','DR01');            
  insert into DRSpeciality(SID,Speciality,DRID) values ('2','Child Specialist','DRO2');
  insert into DRSpeciality(SID,Speciality,DRID) values ('3','Transplantation','DRO3');
   insert into DRSpeciality(SID,Speciality,DRID) values ('4','Cardiology','DRO4');

  
   
	
 create Table timeshedule( tid int identity (1,1) not null,
  timing Varchar(50) Null,
   DRID Varchar(50) Null ,
   Primary Key (tid));
  
  insert into timeshedule(timing,DRID) values ('9pm- 8am','DR01');
  insert into timeshedule(timing,DRID) values ('10am - 6pm','DR02');
  insert into timeshedule(timing,DRID) values ('2pm - 7pm','DR03');
  insert into timeshedule(timing,DRID) values ('2pm- 5pm','DR04');

  select *from DDoctor;
  --select *from   Speciality;




  create Table Doctor( Dept_ID int identity (1,1) not null,
  DRID varchar(50) Null,
   DRName varchar(50) Null,
   DRLastname varchar(50) Null,
  DrSpeciality varchar(50) Null,
   Post varchar(50) Null,
   
   Qualification varchar(50) Null,
  
   PID varchar(50) Null,
  Primary Key (Dept_ID));
  
	insert into Doctor(DRID,DRName,DRLastname,DrSpeciality,Post,Qualification,PID) values ('DR01','Zafar','Aman','Anhesthesiya','Doctor','MMBS','')
	insert into Doctor(DRID,DRName,DRLastname,DrSpeciality,Post,Qualification,PID) values ('DR02','Waqas','Ali','Child Specialist','Doctor','MMBS,FCPS','')
	insert into Doctor(DRID,DRName,DRLastname,DrSpeciality,Post,Qualification,PID) values ('DR03','Azam','Aman','Transplantation','Doctor','MMBS,FCPS,RMP','')
	insert into Doctor(DRID,DRName,DRLastname,DrSpeciality,Post,Qualification,PID) values ('DR04','Ameen','Khan','Cardiology','Doctor','MMBS,FCPS,RMP','')

	

	--select *from
 --Zafar
 create Table Sedule( i int identity (1,1) not null,
  Location Varchar(50) Null,
   SDay  Varchar(50) Null ,
   Sfrom  Varchar(50) Null ,
   STo  Varchar(50) Null ,
   DRName Varchar(50) Null,
   Primary Key (i));

  select *from Sedule;
  insert into Sedule(Location,SDay,Sfrom,STo,DRName) values ('CC Nazerali Walji Building 2nd Floor','Monday','17:00','19:00','Zafar');
 insert into Sedule(Location, SDay,Sfrom,STo,DRName) values ('CLIFTON MEDICAL SERVICES - GROUND FLOOR','Tuesday','15:30','18:30','Zafar');
 insert into Sedule(Location, SDay,Sfrom,STo,DRName) values ('CC Nazerali Walji Building 2nd Floor','Thursday','14:00','17:00','Zafar');
 insert into Sedule(Location, SDay,Sfrom,STo,DRName) values ('CC Nazerali Walji Building 2nd Floor','Friday','9:00','12:00','Zafar');

 --Waqas
 create Table Waqas( i int identity (1,1) not null,
  Location Varchar(50) Null,
   SDay  Varchar(50) Null ,
   Sfrom  Varchar(50) Null ,
   STo  Varchar(50) Null ,
  
   Primary Key (i));

  
 insert into  Waqas(Location,SDay,Sfrom,STo) values ('Jena Bai Building 2nd Floor','Tuesday','09:30','12:00');
 insert into  Waqas(Location, SDay,Sfrom,STo) values ('Jena Bai Building 2nd Floor','Wednesday','14:00','17:00');
 insert into  Waqas(Location, SDay,Sfrom,STo) values ('Jena Bai Building 2nd Floor','Thursday','14:00','17:00');
 insert into  Waqas(Location, SDay,Sfrom,STo) values ('Community Health Centre','Friday','14:00','17:00');
 insert into  Waqas(Location, SDay,Sfrom,STo) values ('Jena Bai Building 2nd Floor','Saturday','10:00','12:00');
 
--4'Ameen
 --3Azam

 create Table Azam( i int identity (1,1) not null,
  Location Varchar(50) Null,
   SDay  Varchar(50) Null ,
   Sfrom  Varchar(50) Null ,
   STo  Varchar(50) Null ,
    Primary Key (i));

 insert into  Azam(Location,SDay,Sfrom,STo) values ('CC Ibn-e-Zuhr Building 1st Floor','Wednesday','08:45','11:30');
 insert into  Azam(Location, SDay,Sfrom,STo) values ('Consulting Clinic- 4 & 6','Thursday','13:30','17:00');
 insert into  Azam(Location, SDay,Sfrom,STo) values ('Consulting Clinic- 4 & 6','Friday','08:30','10:30');
 insert into  Azam(Location, SDay,Sfrom,STo) values ('Consulting Clinic-4 & 6','Saturday','09:00','15:00');
 
 create Table Ameen( i int identity (1,1) not null,
  Location Varchar(50) Null,
   SDay  Varchar(50) Null ,
   Sfrom  Varchar(50) Null ,
   STo  Varchar(50) Null ,
    Primary Key (i));

 insert into  Ameen(Location,SDay,Sfrom,STo) values ('KHARADAR - Aga Khan Diagnostic Centre Kharadar','Monday','11:00','12:00');
 insert into  Ameen(Location, SDay,Sfrom,STo) values ('KHARADAR - Aga Khan Diagnostic Centre Kharadar','Wednesday','11:00','12:00');
 insert into  Ameen(Location, SDay,Sfrom,STo) values ('KHARADAR - Aga Khan Diagnostic Centre Kharadar','Thursday','11:00','12:00');


 Create table Patientinfo(ID int identity(001 , 1) not Null,

   MRNo varchar(50) Null,
   P_FName varchar(50) Null,
   P_MidName varchar(50) Null,
   P_LName varchar(50) Null,
   DOB varchar(50) Null,
   Gender varchar(50) Null,
   Pmobile varchar(50) Null,
  
   PPh# varchar(50) Null,
   Contry varchar(50) Null,
   PEmail varchar(50) Null,
   DrName varchar(50) Null,
   Disease varchar(50) Null,
   P_Status varchar(50) Null,
   Primary Key (ID));
   insert into Patientinfo(MRNo,P_FName,P_MidName,P_LName,DOB,Gender,Pmobile,PPh#,Contry,PEmail,DrName,Disease,P_Status)
    values ('P01','Ali','Khan','Rajar','01-07-2001','Male','+923311819990','032434342','Pakistan','khan@gmail.com','Zafar','Anhesthesiya','SFA')

	select *from Patientinfo;


	Delete  from Doctor where PID = 'P001';
	Delete from Doctor where PID = 'P002';
	Delete from Doctor where PID = 'P003';
	Delete from Doctor where PID = 'P004';

	create Table LOGIN(ID int identity (1,1) Not Null,
	userid varchar(50) null,
	pass varchar(50) null,
    Primary Key (ID))

	insert into LOGIN(userid,pass) values('USER','123');
	insert into LOGIN(userid,pass) values('ADMIN','AGA');
	select *from  Doctor;
	select *from Patientinfo;