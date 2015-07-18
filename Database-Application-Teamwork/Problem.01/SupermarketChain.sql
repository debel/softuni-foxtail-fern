--------------------------------------------------------
--  File created - Saturday-July-18-2015   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table Measures
--------------------------------------------------------

  CREATE TABLE "JINJAAR"."Measures" ("Id" NUMBER(10,0), "MeasureName" NCLOB, "Product_Id" NUMBER(10,0))
--------------------------------------------------------
--  DDL for Table Products
--------------------------------------------------------

  CREATE TABLE "JINJAAR"."Products" ("Id" NUMBER(10,0), "ProductName" NCLOB, "Price" BINARY_DOUBLE, "VendorId" NUMBER(10,0), "MeasureId" NUMBER(10,0))
--------------------------------------------------------
--  DDL for Table Vendors
--------------------------------------------------------

  CREATE TABLE "JINJAAR"."Vendors" ("Id" NUMBER(10,0), "VendorName" NCLOB, "Product_Id" NUMBER(10,0))
REM INSERTING into JINJAAR."Measures"
SET DEFINE OFF;
Insert into JINJAAR."Measures" ("Id","Product_Id") values (1,null);
Insert into JINJAAR."Measures" ("Id","Product_Id") values (2,null);
Insert into JINJAAR."Measures" ("Id","Product_Id") values (3,null);
REM INSERTING into JINJAAR."Products"
SET DEFINE OFF;
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (1,'0.86',1,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (2,'7.56',2,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (3,'1.03',4,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (4,'2.2',1,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (5,'1.5',5,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (6,'25.0',7,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (7,'1.1',6,3);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (8,'2.5',8,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (9,'0.7',1,3);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (10,'2.6',1,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (11,'8.9',3,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (12,'1.0',9,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (13,'0.9',1,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (14,'5.0',10,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (15,'2.5',1,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (16,'1.7',1,2);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (17,'0.69',6,3);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (18,'1.5',3,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (19,'3.0',3,1);
Insert into JINJAAR."Products" ("Id","Price","VendorId","MeasureId") values (20,'2.3',2,1);
REM INSERTING into JINJAAR."Vendors"
SET DEFINE OFF;
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (1,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (2,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (3,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (4,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (5,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (6,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (7,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (8,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (9,null);
Insert into JINJAAR."Vendors" ("Id","Product_Id") values (10,null);
--------------------------------------------------------
--  Constraints for Table Measures
--------------------------------------------------------

  ALTER TABLE "JINJAAR"."Measures" ADD CONSTRAINT "PK_Measures" PRIMARY KEY ("Id") ENABLE
  ALTER TABLE "JINJAAR"."Measures" MODIFY ("Id" NOT NULL ENABLE)
--------------------------------------------------------
--  Constraints for Table Products
--------------------------------------------------------

  ALTER TABLE "JINJAAR"."Products" ADD CONSTRAINT "PK_Products" PRIMARY KEY ("Id") ENABLE
  ALTER TABLE "JINJAAR"."Products" MODIFY ("Price" NOT NULL ENABLE)
  ALTER TABLE "JINJAAR"."Products" MODIFY ("Id" NOT NULL ENABLE)
--------------------------------------------------------
--  Constraints for Table Vendors
--------------------------------------------------------

  ALTER TABLE "JINJAAR"."Vendors" ADD CONSTRAINT "PK_Vendors" PRIMARY KEY ("Id") ENABLE
  ALTER TABLE "JINJAAR"."Vendors" MODIFY ("Id" NOT NULL ENABLE)
--------------------------------------------------------
--  Ref Constraints for Table Measures
--------------------------------------------------------

  ALTER TABLE "JINJAAR"."Measures" ADD CONSTRAINT "FK_Measures_Product_Id" FOREIGN KEY ("Product_Id") REFERENCES "JINJAAR"."Products" ("Id") ENABLE
--------------------------------------------------------
--  Ref Constraints for Table Vendors
--------------------------------------------------------

  ALTER TABLE "JINJAAR"."Vendors" ADD CONSTRAINT "FK_Vendors_Product_Id" FOREIGN KEY ("Product_Id") REFERENCES "JINJAAR"."Products" ("Id") ENABLE
