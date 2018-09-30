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