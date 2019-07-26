# Тестовое задание для кандидата на вакансию C# разработчика

## Установка

Можете клонировать репозиторий или загрузить файл. 
Для того чтобы установить библиотеки
> Сборка -> Пере собрать решения

Чтобы запустить тесты
> Тест -> Отладка -> Все тесты (Ctrl+L, Ctrl+A)

## Запросы

```c#
http://localhost:xxxx/api/values/{id} // HttpGet, Возвращает курс по идентификатору
Пример: https://localhost:44309/api/values/417
Ответ: 90,4659/100

Пример: https://localhost:44309/api/values/4170
Ответ: (No Response Data)

http://localhost:xxxx/api/values/getbatch // HttpGet, Загружает XML файл из базы
Примео: https://localhost:44309/api/values/getbatch
Ответ: File (BANK_YYYYMMDD_{ID}.xml)
```

## Библиотеки

| Plugin | LINK |
| ------ | ------ |
| Sqlite | https://www.sqlite.org/ |

## База данных
Для удобства использовал встроенную библиотеку для БД Sqlite. 

```sql
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "SubjectRoles" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"CustomerCode"	TEXT,
	"RoleOfCustomer"	TEXT,
	"RealEndDate"	TEXT,
	"GuarantorRelationship"	TEXT,
	"ContractId"	INTEGER,
	CONSTRAINT "FK_SubjectRoles_Contracts_ContractId" FOREIGN KEY("ContractId") REFERENCES "Contracts"("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "Batches" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"CurentId"	INTEGER NOT NULL,
	"BatchIdentifier"	TEXT,
	"ContractId"	INTEGER,
	CONSTRAINT "FK_Batches_Contracts_ContractId" FOREIGN KEY("ContractId") REFERENCES "Contracts"("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "Contracts" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"ContractCode"	TEXT,
	"ContractDataId"	INTEGER,
	CONSTRAINT "FK_Contracts_ContractDatas_ContractDataId" FOREIGN KEY("ContractDataId") REFERENCES "ContractDatas"("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "ContractDatas" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Branch"	TEXT,
	"PhaseOfContract"	TEXT,
	"ContractStatus"	TEXT,
	"TypeOfContract"	TEXT,
	"ContractSubtype"	TEXT,
	"OwnershipType"	TEXT,
	"PurposeOfFinancing"	TEXT,
	"CurrencyOfContract"	TEXT,
	"TotalAmountId"	INTEGER,
	"NextPaymentDate"	TEXT,
	"TotalMonthlyPaymentId"	INTEGER,
	"PaymentPeriodicity"	TEXT,
	"StartDate"	TEXT,
	"RestructuringDate"	TEXT,
	"ExpectedEndDate"	TEXT,
	"RealEndDate"	TEXT,
	"NegativeStatusOfContract"	TEXT,
	"ProlongationAmountId"	INTEGER,
	"ProlongationDate"	TEXT,
	CONSTRAINT "FK_ContractDatas_TotalAmounts_ProlongationAmountId" FOREIGN KEY("ProlongationAmountId") REFERENCES "TotalAmounts"("Id") ON DELETE RESTRICT,
	CONSTRAINT "FK_ContractDatas_TotalAmounts_TotalAmountId" FOREIGN KEY("TotalAmountId") REFERENCES "TotalAmounts"("Id") ON DELETE RESTRICT,
	CONSTRAINT "FK_ContractDatas_TotalAmounts_TotalMonthlyPaymentId" FOREIGN KEY("TotalMonthlyPaymentId") REFERENCES "TotalAmounts"("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "TotalAmounts" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Value"	TEXT,
	"Currency"	TEXT
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
INSERT INTO "SubjectRoles" VALUES (1,'Guarantor','2018-01-15','1','1',1);
INSERT INTO "SubjectRoles" VALUES (2,'Guarantor','2018-01-15','2','1',1);
INSERT INTO "SubjectRoles" VALUES (3,'Guarantor','2018-01-15','3','1',1);
INSERT INTO "Batches" VALUES (1,5,'1',1);
INSERT INTO "Contracts" VALUES (1,'2',2);
INSERT INTO "ContractDatas" VALUES (2,'Branch0','Open','GrantedAndActivated','Installment','ConsumerLoan','Individual','Construct','USD',1,'2018-05-15',3,'2','2018-01-15','2018-01-15','2018-01-15',NULL,NULL,NULL,'2018-01-15');
INSERT INTO "TotalAmounts" VALUES (1,'1000','USD');
INSERT INTO "TotalAmounts" VALUES (2,'2000','USD');
INSERT INTO "TotalAmounts" VALUES (3,'0','USD');
INSERT INTO "__EFMigrationsHistory" VALUES ('20190726101232_Init','2.2.6-servicing-10079');
CREATE INDEX IF NOT EXISTS "IX_SubjectRoles_ContractId" ON "SubjectRoles" (
	"ContractId"
);
CREATE INDEX IF NOT EXISTS "IX_Contracts_ContractDataId" ON "Contracts" (
	"ContractDataId"
);
CREATE INDEX IF NOT EXISTS "IX_ContractDatas_TotalMonthlyPaymentId" ON "ContractDatas" (
	"TotalMonthlyPaymentId"
);
CREATE INDEX IF NOT EXISTS "IX_ContractDatas_TotalAmountId" ON "ContractDatas" (
	"TotalAmountId"
);
CREATE INDEX IF NOT EXISTS "IX_ContractDatas_ProlongationAmountId" ON "ContractDatas" (
	"ProlongationAmountId"
);
CREATE INDEX IF NOT EXISTS "IX_Batches_ContractId" ON "Batches" (
	"ContractId"
);
COMMIT;
```
