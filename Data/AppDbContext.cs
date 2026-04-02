using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<ProjectTask> ProjectTasks => Set<ProjectTask>();
    public DbSet<GradeRecord> GradeRecords => Set<GradeRecord>();
    public DbSet<Team> Teams => Set<Team>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Отбор А" },
            new Team { Id = 2, Name = "Отбор Б" }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Иван", LastName = "Илиев", Age = 16, Email = "ivan.iliev@school.bg", TeamId = 1 },
            new Student { Id = 2, FirstName = "Мария", LastName = "Петрова", Age = 17, Email = "maria.petrova@school.bg", TeamId = 1 },
            new Student { Id = 3, FirstName = "Георги", LastName = "Димитров", Age = 16, Email = "georgi.dimitrov@school.bg", TeamId = 2 },
            new Student { Id = 4, FirstName = "Елена", LastName = "Стоянова", Age = 17, Email = "elena.stoyanova@school.bg", TeamId = 2 },
            new Student { Id = 5, FirstName = "Никола", LastName = "Колев", Age = 18, Email = "nikola.kolev@school.bg", TeamId = 1 }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Математика", Teacher = "г-жа Николова", Credits = 5 },
            new Course { Id = 2, Name = "Информатика", Teacher = "г-н Георгиев", Credits = 6 }
        );

        modelBuilder.Entity<ProjectTask>().HasData(
            new ProjectTask { Id = 1, Title = "Създаване на бизнес слой", Description = "Да има поне 5 класа данни", Deadline = new DateTime(2026, 3, 18), IsCompleted = true },
            new ProjectTask { Id = 2, Title = "CRUD имплементация", Description = "Добавяне, редакция, триене на ученици", Deadline = new DateTime(2026, 3, 18), IsCompleted = true }
        );

        modelBuilder.Entity<GradeRecord>().HasData(
            new GradeRecord { Id = 1, StudentId = 1, CourseId = 1, Grade = 5.50m },
            new GradeRecord { Id = 2, StudentId = 2, CourseId = 2, Grade = 6.00m }
        );
    }
}
