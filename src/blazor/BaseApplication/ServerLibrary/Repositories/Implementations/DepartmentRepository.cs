﻿namespace ServerLibrary.Repositories.Implementations;

public class DepartmentRepository(AppDbContext appDbContext) : IGenericRepository<Department>
{
    public async Task<List<Department>> GetAll()
    {
        return await appDbContext.Departments.ToListAsync();
    }

    public async Task<Department> GetById(int id)
    {
        return (await appDbContext.Departments.FindAsync(id))!;
    }

    public async Task<GeneralResponse> Create(Department item)
    {
        if (!await CheckName(item.Name!)) return AlreadyExist();
        {
            appDbContext.Departments.Add(item);
            await Commit();
            return Success();
        }
    }

    public async Task<GeneralResponse> Update(Department item)
    {
        var dep = await appDbContext.Departments.FindAsync(item.Id);
        if (dep is null) return NotFound();
        dep.Name = item.Name;
        await Commit();
        return Success();
    }

    public async Task<GeneralResponse> DeleteById(int id)
    {
        var dep = await appDbContext.Departments.FindAsync(id);
        if (dep is null) return NotFound();

        appDbContext.Departments.Remove(dep);
        await Commit();
        return Success();
    }

    private static GeneralResponse NotFound() => new(false, "Department not found");
    private static GeneralResponse Success() => new(true, "Process completed");
    private static GeneralResponse AlreadyExist() => new(false, "Department already exist");
    private async Task Commit() => await appDbContext.SaveChangesAsync();

    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Departments
            .FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}