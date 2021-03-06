// <auto-generated />
using System;
using APM.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APM.Repository.Migrations
{
    [DbContext(typeof(APMDbContext))]
    [Migration("20220113163735_lastchangee")]
    partial class lastchangee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("APM")
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APM.Entities.Entities.Activity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ACTIVITY_CREATOR")
                        .HasColumnType("int");

                    b.Property<DateTime>("ACTIVITY_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("ACTIVITY_DETAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ACTIVITY_EMPLOYEE")
                        .HasColumnType("int");

                    b.Property<int>("ACTIVITY_PRIORITY")
                        .HasColumnType("int");

                    b.Property<bool>("ACTIVITY_STATUS")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("END_TIME")
                        .HasColumnType("time");

                    b.Property<bool>("INVOICE")
                        .HasColumnType("bit");

                    b.Property<string>("IndirectCustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LOCATION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PROJECT_NUMBER")
                        .HasColumnType("int");

                    b.Property<string>("REFERENCE_NO")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<TimeSpan>("START_TIME")
                        .HasColumnType("time");

                    b.Property<double>("WHOUR")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ACTIVITY_CREATOR");

                    b.HasIndex("ACTIVITY_EMPLOYEE");

                    b.HasIndex("ACTIVITY_PRIORITY");

                    b.HasIndex("PROJECT_NUMBER");

                    b.ToTable("ACTIVITIES");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ACTIVITY_CREATOR = 1,
                            ACTIVITY_DATE = new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ACTIVITY_DETAIL = "aktivite1",
                            ACTIVITY_EMPLOYEE = 1,
                            ACTIVITY_PRIORITY = 3,
                            ACTIVITY_STATUS = false,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 291, DateTimeKind.Local).AddTicks(8419),
                            CREATED_TIME = new TimeSpan(706542918442),
                            END_TIME = new TimeSpan(0, 18, 15, 0, 0),
                            INVOICE = false,
                            LOCATION = "Şirket İçi",
                            PROJECT_NUMBER = 1,
                            START_TIME = new TimeSpan(0, 10, 45, 0, 0),
                            WHOUR = 8.0
                        },
                        new
                        {
                            ID = 2,
                            ACTIVITY_CREATOR = 2,
                            ACTIVITY_DATE = new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ACTIVITY_DETAIL = "aktivite2",
                            ACTIVITY_EMPLOYEE = 3,
                            ACTIVITY_PRIORITY = 3,
                            ACTIVITY_STATUS = true,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 292, DateTimeKind.Local).AddTicks(5726),
                            CREATED_TIME = new TimeSpan(706542925746),
                            INVOICE = false,
                            LOCATION = "Uzaktan",
                            PROJECT_NUMBER = 1,
                            START_TIME = new TimeSpan(0, 11, 45, 0, 0),
                            WHOUR = 4.4500000000000002
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<string>("CUSTOMER_ADRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("CUSTOMER_CREATOR")
                        .HasColumnType("int");

                    b.Property<string>("CUSTOMER_MAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("CUSTOMER_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("CUSTOMER_PHONE_NO")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<bool>("CUSTOMER_STATUS")
                        .HasColumnType("bit");

                    b.Property<string>("CUSTOMER_TYPE")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.HasIndex("CUSTOMER_CREATOR");

                    b.ToTable("CUSTOMERS");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 289, DateTimeKind.Local).AddTicks(5236),
                            CREATED_TIME = new TimeSpan(706542895259),
                            CUSTOMER_ADRESS = "Maltepe/İstanbul",
                            CUSTOMER_CREATOR = 2,
                            CUSTOMER_MAIL = "xyz1@akinsoft.com.tr",
                            CUSTOMER_NAME = "AkınSoft",
                            CUSTOMER_PHONE_NO = "21632145215",
                            CUSTOMER_STATUS = true,
                            CUSTOMER_TYPE = "Dolaylı"
                        },
                        new
                        {
                            ID = 2,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 290, DateTimeKind.Local).AddTicks(951),
                            CREATED_TIME = new TimeSpan(706542900981),
                            CUSTOMER_ADRESS = "Selçuklu/Konya",
                            CUSTOMER_CREATOR = 2,
                            CUSTOMER_MAIL = "xyz2@ktun.com.tr",
                            CUSTOMER_NAME = "KonyaTeknik",
                            CUSTOMER_PHONE_NO = "2125422311",
                            CUSTOMER_STATUS = true,
                            CUSTOMER_TYPE = "Doğrudan"
                        },
                        new
                        {
                            ID = 3,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 290, DateTimeKind.Local).AddTicks(1125),
                            CREATED_TIME = new TimeSpan(706542901128),
                            CUSTOMER_ADRESS = "Kadıköy/İstanbul",
                            CUSTOMER_CREATOR = 1,
                            CUSTOMER_MAIL = "xyz3@iveco.com.tr",
                            CUSTOMER_NAME = "IVECO",
                            CUSTOMER_PHONE_NO = "2163112400",
                            CUSTOMER_STATUS = true,
                            CUSTOMER_TYPE = "Doğrudan"
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<string>("EMPLOYEE_ADRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("EMPLOYEE_CREATOR")
                        .HasColumnType("int");

                    b.Property<string>("EMPLOYEE_MAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EMPLOYEE_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EMPLOYEE_PHONE_NO")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<bool>("EMPLOYEE_STATUS")
                        .HasColumnType("bit");

                    b.Property<string>("EMPLOYEE_SURNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("EMPLOYEE_TITLE")
                        .HasColumnType("int");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ROLE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EMPLOYEE_CREATOR");

                    b.HasIndex("EMPLOYEE_TITLE");

                    b.ToTable("EMPLOYEES");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 286, DateTimeKind.Local).AddTicks(2561),
                            CREATED_TIME = new TimeSpan(706542880992),
                            EMPLOYEE_ADRESS = "Gölbaşı/Ankara",
                            EMPLOYEE_CREATOR = 1,
                            EMPLOYEE_MAIL = "abc1@gmail.com.tr",
                            EMPLOYEE_NAME = "Okan",
                            EMPLOYEE_PHONE_NO = "5550000000",
                            EMPLOYEE_STATUS = true,
                            EMPLOYEE_SURNAME = "Şahbaz",
                            EMPLOYEE_TITLE = 1,
                            PASSWORD = "qPHubpjeaXvlBFg8JJb0DA==",
                            ROLE = "ADMIN"
                        },
                        new
                        {
                            ID = 2,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 289, DateTimeKind.Local).AddTicks(200),
                            CREATED_TIME = new TimeSpan(706542890237),
                            EMPLOYEE_ADRESS = "Üsküdar/İstanbul",
                            EMPLOYEE_CREATOR = 2,
                            EMPLOYEE_MAIL = "abc2@gmail.com.tr",
                            EMPLOYEE_NAME = "İlker",
                            EMPLOYEE_PHONE_NO = "5550000000",
                            EMPLOYEE_STATUS = true,
                            EMPLOYEE_SURNAME = "Tekin",
                            EMPLOYEE_TITLE = 2,
                            PASSWORD = "qPHubpjeaXvlBFg8JJb0DA==",
                            ROLE = "ADMIN"
                        },
                        new
                        {
                            ID = 3,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 289, DateTimeKind.Local).AddTicks(977),
                            CREATED_TIME = new TimeSpan(706542891009),
                            EMPLOYEE_ADRESS = "Selçuklu/Konya",
                            EMPLOYEE_CREATOR = 3,
                            EMPLOYEE_MAIL = "abc3@gmail.com.tr",
                            EMPLOYEE_NAME = "Ahmet",
                            EMPLOYEE_PHONE_NO = "5550000000",
                            EMPLOYEE_STATUS = true,
                            EMPLOYEE_SURNAME = "Seçkin",
                            EMPLOYEE_TITLE = 2,
                            PASSWORD = "qPHubpjeaXvlBFg8JJb0DA==",
                            ROLE = "NORMAL"
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.Level", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LEVEL_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("i")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("LEVELS");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LEVEL_NAME = "Kabul Edildi",
                            i = 1
                        },
                        new
                        {
                            ID = 2,
                            LEVEL_NAME = "Planlanıyor",
                            i = 2
                        },
                        new
                        {
                            ID = 3,
                            LEVEL_NAME = "Tasarımda",
                            i = 3
                        },
                        new
                        {
                            ID = 4,
                            LEVEL_NAME = "Kodlamada",
                            i = 4
                        },
                        new
                        {
                            ID = 5,
                            LEVEL_NAME = "Test",
                            i = 5
                        },
                        new
                        {
                            ID = 6,
                            LEVEL_NAME = "Tamamlandı",
                            i = 6
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("END_TIME")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("START_TIME")
                        .HasColumnType("datetime2");

                    b.Property<string>("TEXT_INFO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("NOTIFICATION");
                });

            modelBuilder.Entity("APM.Entities.Entities.Priority", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PRIORITY_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("PRIORITY");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            PRIORITY_NAME = "Çok Acil"
                        },
                        new
                        {
                            ID = 2,
                            PRIORITY_NAME = "Acil"
                        },
                        new
                        {
                            ID = 3,
                            PRIORITY_NAME = "Normal"
                        },
                        new
                        {
                            ID = 4,
                            PRIORITY_NAME = "Acil Değil"
                        },
                        new
                        {
                            ID = 5,
                            PRIORITY_NAME = "Önemli Değil"
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("CREATED_TIME")
                        .HasColumnType("time");

                    b.Property<int>("CUSTOMER_NUMBER")
                        .HasColumnType("int");

                    b.Property<DateTime?>("END_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ESTIMATE_END_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ESTIMATE_START_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("PROJECT_CREATOR")
                        .HasColumnType("int");

                    b.Property<int>("PROJECT_LEVEL")
                        .HasColumnType("int");

                    b.Property<string>("PROJECT_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("PROJECT_STATUS")
                        .HasColumnType("bit");

                    b.Property<int>("PROJECT_TYPE")
                        .HasColumnType("int");

                    b.Property<DateTime?>("START_DATE")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CUSTOMER_NUMBER");

                    b.HasIndex("PROJECT_CREATOR");

                    b.HasIndex("PROJECT_LEVEL");

                    b.HasIndex("PROJECT_TYPE");

                    b.ToTable("PROJECTS");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 290, DateTimeKind.Local).AddTicks(6332),
                            CREATED_TIME = new TimeSpan(706542906365),
                            CUSTOMER_NUMBER = 3,
                            END_DATE = new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_END_DATE = new DateTime(2021, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_START_DATE = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PROJECT_CREATOR = 1,
                            PROJECT_LEVEL = 1,
                            PROJECT_NAME = "APM",
                            PROJECT_STATUS = true,
                            PROJECT_TYPE = 2,
                            START_DATE = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            CREATED_DATE = new DateTime(2022, 1, 13, 19, 37, 34, 291, DateTimeKind.Local).AddTicks(4197),
                            CREATED_TIME = new TimeSpan(706542914225),
                            CUSTOMER_NUMBER = 1,
                            END_DATE = new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_END_DATE = new DateTime(2021, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ESTIMATE_START_DATE = new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PROJECT_CREATOR = 2,
                            PROJECT_LEVEL = 3,
                            PROJECT_NAME = "Fiorent",
                            PROJECT_STATUS = true,
                            PROJECT_TYPE = 1,
                            START_DATE = new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.ProjectEmployee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID", "ProjectID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectEmployees");
                });

            modelBuilder.Entity("APM.Entities.Entities.Project_Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TYPE_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("PROJECT_TYPE");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TYPE_NAME = "Web"
                        },
                        new
                        {
                            ID = 2,
                            TYPE_NAME = "SAP-ABAB"
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.PublicHoliday", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime2");

                    b.Property<string>("etag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("htmlLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iCalUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("sequence")
                        .HasColumnType("int");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("transparency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("visibility")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PUBLICHOLIDAYS");
                });

            modelBuilder.Entity("APM.Entities.Entities.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TITLE_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("TITLES");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            TITLE_NAME = "Junior"
                        },
                        new
                        {
                            ID = 2,
                            TITLE_NAME = "Senior"
                        });
                });

            modelBuilder.Entity("APM.Entities.Entities.Activity", b =>
                {
                    b.HasOne("APM.Entities.Entities.Employee", "CREATED_EMPLOYEE")
                        .WithMany("CREATED_ACTIVITY")
                        .HasForeignKey("ACTIVITY_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Employee", "EMPLOYEE")
                        .WithMany("ACTIVITIES")
                        .HasForeignKey("ACTIVITY_EMPLOYEE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Priority", "PRIORITY")
                        .WithMany("ACTIVITIES")
                        .HasForeignKey("ACTIVITY_PRIORITY")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Project", "PROJECT")
                        .WithMany("ACTIVITIES")
                        .HasForeignKey("PROJECT_NUMBER")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("APM.Entities.Entities.Customer", b =>
                {
                    b.HasOne("APM.Entities.Entities.Employee", "CREATED_CUSTOMER")
                        .WithMany("CUSTOMERS")
                        .HasForeignKey("CUSTOMER_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("APM.Entities.Entities.Employee", b =>
                {
                    b.HasOne("APM.Entities.Entities.Employee", "CREATED_EMPLOYEE")
                        .WithMany("CREATED_EMPLOYEES")
                        .HasForeignKey("EMPLOYEE_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Title", "TITLE")
                        .WithMany("EMPLOYEES")
                        .HasForeignKey("EMPLOYEE_TITLE")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("APM.Entities.Entities.Project", b =>
                {
                    b.HasOne("APM.Entities.Entities.Customer", "CUSTOMER")
                        .WithMany("PROJECTS")
                        .HasForeignKey("CUSTOMER_NUMBER")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Employee", "CREATED_EMPLOYEE")
                        .WithMany("CREATED_PROJECTS")
                        .HasForeignKey("PROJECT_CREATOR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Level", "LEVEL")
                        .WithMany("PROJECTS")
                        .HasForeignKey("PROJECT_LEVEL")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Project_Type", "PROJECT_TYPE_")
                        .WithMany("PROJECTS")
                        .HasForeignKey("PROJECT_TYPE")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("APM.Entities.Entities.ProjectEmployee", b =>
                {
                    b.HasOne("APM.Entities.Entities.Employee", "EMPLOYEE")
                        .WithMany("PROJECTEMPLOYEE")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APM.Entities.Entities.Project", "PROJECT")
                        .WithMany("PROJECTEMPLOYEE")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
