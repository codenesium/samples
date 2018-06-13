using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractProjectGroupRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProjectGroupRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProjectGroup>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ProjectGroup> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ProjectGroup> Create(ProjectGroup item)
                {
                        this.Context.Set<ProjectGroup>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProjectGroup item)
                {
                        var entity = this.Context.Set<ProjectGroup>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ProjectGroup>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        ProjectGroup record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProjectGroup>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ProjectGroup> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<List<ProjectGroup>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.SearchLinqEF(x => x.DataVersion == dataVersion);

                        return records;
                }

                protected async Task<List<ProjectGroup>> Where(Expression<Func<ProjectGroup, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ProjectGroup> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ProjectGroup>> SearchLinqEF(Expression<Func<ProjectGroup, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProjectGroup.Id)} ASC";
                        }

                        return await this.Context.Set<ProjectGroup>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProjectGroup>();
                }

                private async Task<List<ProjectGroup>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProjectGroup.Id)} ASC";
                        }

                        return await this.Context.Set<ProjectGroup>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProjectGroup>();
                }

                private async Task<ProjectGroup> GetById(string id)
                {
                        List<ProjectGroup> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>2df0d368e3a0474145b65384bac112c5</Hash>
</Codenesium>*/