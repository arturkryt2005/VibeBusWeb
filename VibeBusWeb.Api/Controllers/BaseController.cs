using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VibeBusWeb.Application.Data.Interfaces;
using VibeBusWeb.Database.Data;

namespace VibeBusWeb.Api.Controllers;

[Route("[controller]/[action]")]
public class BaseController<TEntity> : ControllerBase where TEntity : class, IHaveId, new()
{
    private readonly DbConnectionContext _dbConnectionContext;

    public BaseController(DbConnectionContext dbConnectionContext)
    {
        _dbConnectionContext = dbConnectionContext;
    }

    [HttpGet]
    public async Task<IEnumerable<TEntity>?> GetAll()
    {
        var entities = await _dbConnectionContext.Set<TEntity>().ToListAsync();
        return entities;
    }

    [HttpPost]
    public async Task Add([FromBody] TEntity entity)
    {
        await _dbConnectionContext.Set<TEntity>().AddAsync(entity);
        await _dbConnectionContext.SaveChangesAsync();
    }

    [HttpPut]
    public async Task Update([FromBody] TEntity entity)
    {
        _dbConnectionContext.Set<TEntity>().Update(entity);
        await _dbConnectionContext.SaveChangesAsync();
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        var entity = new TEntity
        {
            Id = id
        };

        _dbConnectionContext.Set<TEntity>().Remove(entity);
        await _dbConnectionContext.SaveChangesAsync();
    }
}