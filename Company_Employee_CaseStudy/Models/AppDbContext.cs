using Microsoft.EntityFrameworkCore;

namespace Company_Employee_CaseStudy.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().Property(e => e.Role).HasDefaultValue("Employee");

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Project>()
                .HasOne(e => e.Department)
                .WithMany(e => e.Projects)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<EmployeeProject>()
                .HasIndex(ep => new { ep.EmployeeId, ep.ProjectId })
                .IsUnique();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    ApplicationUserId = 1,
                    Name = "admin",
                    Password = "admin123",
                    Email = "admin@example.com",
                    Role = "Admin"
                },
                new ApplicationUser
                {
                    ApplicationUserId = 2,
                    Name = "employee",
                    Password = "employee123",
                    Email = "employee@example.com",
                    Role = "Employee"
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    Name = "HR",
                    Location = "Building A"
                },
                new Department
                {
                    DepartmentId = 2,
                    Name = "IT",
                    Location = "Building B"
                },
                new Department
                {
                    DepartmentId = 3,
                    Name = "Finance",
                    Location = "Building C"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FullName = "John Doe",
                    Email = "john@ex.com",
                    Salary = 50000,
                    DepartmentId = 1,
                    HireDate = new DateTime(2020, 1, 1),
                    ProjectId = 1
                },
                new Employee
                {
                    EmployeeId = 2,
                    FullName = "Jane Smith",
                    Email = "jane@ex.com",
                    Salary = 60000,
                    DepartmentId = 2,
                    HireDate = new DateTime(2021, 2, 1),
                    ProjectId = 2
                }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    Name = "Project A",
                    Description = "Description for Project A",
                    DepartmentId = 1,
                    StartDate = new DateTime(2023, 1, 1),
                    Budget = 100000
                },
                new Project
                {
                    ProjectId = 2,
                    Name = "Project B",
                    Description = "Description for Project B",
                    DepartmentId = 2,
                    StartDate = new DateTime(2023, 2, 1),
                    Budget = 200000
                }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    EmployeeProjectId = 1,
                    EmployeeId = 1,
                    ProjectId = 1,
                    AssigmentDate = new DateTime(2023, 1, 1),
                    AssignedRole = "Admin"
                },
                new EmployeeProject
                {
                    EmployeeProjectId = 2,
                    EmployeeId = 2,
                    ProjectId = 2,
                    AssigmentDate = new DateTime(2023, 2, 1),
                    AssignedRole = "Employee"
                }
            );
        }
    }
}