using System;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Interfaces;

public interface ICRUDService<T>
{
    public Task Create(T item);
    public Task<T?> Read(string id);
    public Task Update(T item);
    public Task<bool> Delete(string id);
}
