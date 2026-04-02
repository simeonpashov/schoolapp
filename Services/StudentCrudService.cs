using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;

namespace SchoolProject.Services;

public class StudentCrudService(AppDbContext dbContext)
{
    public async Task<List<Student>> GetAllAsync()
        => await dbContext.Students.AsNoTracking().OrderBy(s => s.Id).ToListAsync();

    public async Task<Student?> GetByIdAsync(int id)
        => await dbContext.Students.FindAsync(id);

    public async Task<Student> CreateAsync(Student student)
    {
        dbContext.Students.Add(student);
        await dbContext.SaveChangesAsync();
        return student;
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        var existing = await dbContext.Students.FindAsync(student.Id);
        if (existing is null)
        {
            return false;
        }

        existing.FirstName = student.FirstName;
        existing.LastName = student.LastName;
        existing.Age = student.Age;
        existing.Email = student.Email;
        existing.TeamId = student.TeamId;

        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await dbContext.Students.FindAsync(id);
        if (existing is null)
        {
            return false;
        }

        dbContext.Students.Remove(existing);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
