# efcore-data-generator

[DatabaseGenerated(DatabaseGeneratedOption.Identity)] และ [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

จะ generate ค่าจาก db ให้อัตโนมัติ ขึ้นอยู่กับ database provider ที่ใช้

เช่น
```
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public DateTime Created { get; set; }
```

จะ auto generate วันและเวลาปัจจุบันให้ใน MySql **แต่ไม่** auto generate ให้บน MSSql

**ใช้วิธีเซตใน Fluent API ชัวกว่า**
```
modelBuilder.Entity<Customers>()
    .Property(b => b.Created)
    .HasDefaultValue(DateTime.Now);
```

### Create Table Query Result (สาเหตุที่ต่างกัน)
MySQL
```
    CREATE TABLE `Customers` (
        `Created` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
        `LastVisited` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        `Id` int NOT NULL AUTO_INCREMENT,
        `UniqueId` int NOT NULL,
        `FirstName` longtext NULL,
        `LastName` longtext NULL,
        CONSTRAINT `PK_Customers` PRIMARY KEY (`Id`)
    );
``` 

MSSQL
```
    CREATE TABLE [Customers] (
        [Created] datetime2 NOT NULL,
        [LastVisited] datetime2 NOT NULL,
        [Id] int NOT NULL IDENTITY,
        [UniqueId] int NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
```