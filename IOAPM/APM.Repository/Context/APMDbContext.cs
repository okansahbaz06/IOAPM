using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using APM.Entities.Entities;

namespace APM.Repository.Context
{
    public class APMDbContext : DbContext
    {

        public APMDbContext(DbContextOptions options)
           : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Project_Type> Project_Types { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("APM");

            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.EmployeeID, pe.ProjectID });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.PROJECT)
                .WithMany(e => e.PROJECTEMPLOYEE)
                .HasForeignKey(pe => pe.ProjectID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.EMPLOYEE)
                .WithMany(p => p.PROJECTEMPLOYEE)
                .HasForeignKey(pe => pe.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Employee>(entity =>
            {
                entity
                .HasOne(employee => employee.TITLE)
                .WithMany(title => title.EMPLOYEES)
                .HasForeignKey(employee => employee.EMPLOYEE_TITLE)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                 .HasOne(employee => employee.CREATED_EMPLOYEE)
                 .WithMany(employee => employee.CREATED_EMPLOYEES)
                 .HasForeignKey(employee => employee.EMPLOYEE_CREATOR)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity
                .HasOne(activity => activity.PROJECT)
                .WithMany(project => project.ACTIVITIES)
                .HasForeignKey(activity => activity.PROJECT_NUMBER)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(activity => activity.CREATED_EMPLOYEE)
                .WithMany(employee => employee.CREATED_ACTIVITY)
                .HasForeignKey(activity => activity.ACTIVITY_CREATOR)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(activity => activity.PRIORITY)
                .WithMany(priority => priority.ACTIVITIES)
                .HasForeignKey(activity => activity.ACTIVITY_PRIORITY)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(activity => activity.EMPLOYEE)
                .WithMany(employee => employee.ACTIVITIES)
                .HasForeignKey(activity => activity.ACTIVITY_EMPLOYEE)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Customer>()
                .HasOne(customer => customer.CREATED_CUSTOMER)
                .WithMany(employee => employee.CUSTOMERS)
                .HasForeignKey(customer => customer.CUSTOMER_CREATOR)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>(entity =>
            {
                entity
                .HasOne(project => project.PROJECT_TYPE_)
                .WithMany(project_type => project_type.PROJECTS)
                .HasForeignKey(project => project.PROJECT_TYPE)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(project => project.CUSTOMER)
                .WithMany(customer => customer.PROJECTS)
                .HasForeignKey(project => project.CUSTOMER_NUMBER)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(project => project.LEVEL)
                .WithMany(level => level.PROJECTS)
                .HasForeignKey(project => project.PROJECT_LEVEL)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(project => project.CREATED_EMPLOYEE)
                .WithMany(employee => employee.CREATED_PROJECTS)
                .HasForeignKey(project => project.PROJECT_CREATOR)
                .OnDelete(DeleteBehavior.Restrict);
            });

            seedData(modelBuilder);
        }

        void seedData(ModelBuilder modelBuilder)
        {
            var titles = new List<Title>
            {
                new Title { ID = 1, TITLE_NAME = "Junior" },
                new Title { ID = 2, TITLE_NAME = "Senior" }
            };
            modelBuilder.Entity<Title>().HasData(titles);

            var levels = new List<Level>
            {
                new Level { ID = 1, LEVEL_NAME = "Kabul Edildi", i = 1 },
                new Level { ID = 2, LEVEL_NAME = "Planlanıyor", i = 2 },
                new Level { ID = 3, LEVEL_NAME = "Tasarımda", i = 3 },
                new Level { ID = 4, LEVEL_NAME = "Kodlamada", i = 4 },
                new Level { ID = 5, LEVEL_NAME = "Test", i = 5 },
                new Level { ID = 6, LEVEL_NAME = "Tamamlandı", i = 6 }
            };
            modelBuilder.Entity<Level>().HasData(levels);

            var priority = new List<Priority>
            {
                new Priority { ID = 1, PRIORITY_NAME = "Çok Acil" },
                new Priority { ID = 2, PRIORITY_NAME = "Acil" },
                new Priority { ID = 3, PRIORITY_NAME = "Normal" },
                new Priority { ID = 4, PRIORITY_NAME = "Acil Değil" },
                new Priority { ID = 5, PRIORITY_NAME = "Önemli Değil" }
            };
            modelBuilder.Entity<Priority>().HasData(priority);

            var project_type = new List<Project_Type>
            {
                new Project_Type { ID = 1, TYPE_NAME = "Web"},
                new Project_Type { ID = 2, TYPE_NAME = "SAP-ABAB"}
            };
            modelBuilder.Entity<Project_Type>().HasData(project_type);


            var employee = new List<Employee>
            {
                new Employee{ ID = 1, EMPLOYEE_NAME = "Okan", EMPLOYEE_SURNAME = "Şahbaz", EMPLOYEE_PHONE_NO = "5550000000", EMPLOYEE_ADRESS = "Gölbaşı/Ankara", EMPLOYEE_MAIL = "abc1@gmail.com.tr", EMPLOYEE_STATUS = true, EMPLOYEE_TITLE = 1, EMPLOYEE_CREATOR = 1, PASSWORD = "qPHubpjeaXvlBFg8JJb0DA==", ROLE = Dto.Roles.ADMIN.ToString() },
                new Employee{ ID = 2, EMPLOYEE_NAME = "İlker", EMPLOYEE_SURNAME = "Tekin", EMPLOYEE_PHONE_NO = "5550000000", EMPLOYEE_ADRESS = "Üsküdar/İstanbul", EMPLOYEE_MAIL = "abc2@gmail.com.tr", EMPLOYEE_STATUS = true, EMPLOYEE_TITLE = 2, EMPLOYEE_CREATOR = 2, PASSWORD = "qPHubpjeaXvlBFg8JJb0DA==",ROLE = Dto.Roles.ADMIN.ToString()},
                new Employee{ ID = 3, EMPLOYEE_NAME = "Ahmet", EMPLOYEE_SURNAME = "Seçkin", EMPLOYEE_PHONE_NO = "5550000000", EMPLOYEE_ADRESS = "Selçuklu/Konya", EMPLOYEE_MAIL = "abc3@gmail.com.tr", EMPLOYEE_STATUS = true, EMPLOYEE_TITLE = 2, EMPLOYEE_CREATOR = 3, PASSWORD =  "qPHubpjeaXvlBFg8JJb0DA==", ROLE = Dto.Roles.NORMAL.ToString()},

            };
            modelBuilder.Entity<Employee>().HasData(employee);

            var customer = new List<Customer>
            {
                new Customer{ ID = 1, CUSTOMER_TYPE = "Dolaylı", CUSTOMER_NAME = "AkınSoft", CUSTOMER_PHONE_NO = "21632145215", CUSTOMER_ADRESS = "Maltepe/İstanbul", CUSTOMER_MAIL = "xyz1@akinsoft.com.tr", CUSTOMER_STATUS = true, CUSTOMER_CREATOR = 2 },
                new Customer{ ID = 2, CUSTOMER_TYPE = "Doğrudan", CUSTOMER_NAME = "KonyaTeknik", CUSTOMER_PHONE_NO = "2125422311", CUSTOMER_ADRESS = "Selçuklu/Konya", CUSTOMER_MAIL = "xyz2@ktun.com.tr", CUSTOMER_STATUS = true, CUSTOMER_CREATOR = 2 },
                new Customer{ ID = 3, CUSTOMER_TYPE = "Doğrudan", CUSTOMER_NAME = "IVECO", CUSTOMER_PHONE_NO = "2163112400", CUSTOMER_ADRESS = "Kadıköy/İstanbul", CUSTOMER_MAIL = "xyz3@iveco.com.tr", CUSTOMER_STATUS = true, CUSTOMER_CREATOR = 1 }
            };
            modelBuilder.Entity<Customer>().HasData(customer);


            var project = new List<Project>
            {
                new Project{ ID = 1, PROJECT_TYPE = 2, PROJECT_NAME = "APM", CUSTOMER_NUMBER = 3, ESTIMATE_START_DATE = new DateTime(2021,10,10), ESTIMATE_END_DATE = new DateTime(2021,12,06), START_DATE = new DateTime(2021,10,10), END_DATE = new DateTime(2019,12,02), PROJECT_STATUS = true, PROJECT_LEVEL = 1, PROJECT_CREATOR = 1},
                new Project{ ID = 2, PROJECT_TYPE = 1, PROJECT_NAME = "Fiorent", CUSTOMER_NUMBER = 1, ESTIMATE_START_DATE = new DateTime(2021,10,15), ESTIMATE_END_DATE = new DateTime(2021,12,20), START_DATE = new DateTime(2021,10,15), END_DATE = new DateTime(2021,12,17), PROJECT_STATUS = true, PROJECT_LEVEL = 3, PROJECT_CREATOR = 2 }
            };
            modelBuilder.Entity<Project>().HasData(project);

            var activity = new List<Activity>
            {
                new Activity{ ID = 1, PROJECT_NUMBER = 1, ACTIVITY_EMPLOYEE = 1, ACTIVITY_DETAIL = "aktivite1", ACTIVITY_DATE = new DateTime(2019,06,20), START_TIME = new TimeSpan(10,45,00), END_TIME = new TimeSpan(18,15,00),WHOUR = 8, LOCATION = "Şirket İçi", ACTIVITY_STATUS = false, ACTIVITY_PRIORITY = 3, ACTIVITY_CREATOR = 1 },
                new Activity{ ID = 2, PROJECT_NUMBER = 1, ACTIVITY_EMPLOYEE = 3, ACTIVITY_DETAIL = "aktivite2", ACTIVITY_DATE = new DateTime(2019,08,10), START_TIME = new TimeSpan(11,45,00),  WHOUR = 4.45, LOCATION = "Uzaktan", ACTIVITY_STATUS = true, ACTIVITY_PRIORITY = 3, ACTIVITY_CREATOR = 2 }
            };
            modelBuilder.Entity<Activity>().HasData(activity);


        }
    }
}
