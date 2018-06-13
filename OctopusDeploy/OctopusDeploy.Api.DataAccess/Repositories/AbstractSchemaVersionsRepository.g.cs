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
        public abstract class AbstractSchemaVersionsRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSchemaVersionsRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SchemaVersions>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<SchemaVersions> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<SchemaVersions> Create(SchemaVersions item)
                {
                        this.Context.Set<SchemaVersions>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SchemaVersions item)
                {
                        var entity = this.Context.Set<SchemaVersions>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<SchemaVersions>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int id)
                {
                        SchemaVersions record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SchemaVersions>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<SchemaVersions>> Where(Expression<Func<SchemaVersions, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SchemaVersions> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SchemaVersions>> SearchLinqEF(Expression<Func<SchemaVersions, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SchemaVersions.Id)} ASC";
                        }

                        return await this.Context.Set<SchemaVersions>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SchemaVersions>();
                }

                private async Task<List<SchemaVersions>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SchemaVersions.Id)} ASC";
                        }

                        return await this.Context.Set<SchemaVersions>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SchemaVersions>();
                }

                private async Task<SchemaVersions> GetById(int id)
                {
                        List<SchemaVersions> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>c66df975ccc132fdfe237ef7c9d1b1c0</Hash>
</Codenesium>*/