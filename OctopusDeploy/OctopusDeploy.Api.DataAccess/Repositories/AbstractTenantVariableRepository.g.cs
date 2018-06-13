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
        public abstract class AbstractTenantVariableRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTenantVariableRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TenantVariable>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<TenantVariable> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<TenantVariable> Create(TenantVariable item)
                {
                        this.Context.Set<TenantVariable>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TenantVariable item)
                {
                        var entity = this.Context.Set<TenantVariable>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<TenantVariable>().Attach(item);
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
                        TenantVariable record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TenantVariable>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<TenantVariable> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId)
                {
                        var records = await this.SearchLinqEF(x => x.TenantId == tenantId && x.OwnerId == ownerId && x.EnvironmentId == environmentId && x.VariableTemplateId == variableTemplateId);

                        return records.FirstOrDefault();
                }
                public async Task<List<TenantVariable>> GetTenantId(string tenantId)
                {
                        var records = await this.SearchLinqEF(x => x.TenantId == tenantId);

                        return records;
                }

                protected async Task<List<TenantVariable>> Where(Expression<Func<TenantVariable, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<TenantVariable> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<TenantVariable>> SearchLinqEF(Expression<Func<TenantVariable, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TenantVariable.Id)} ASC";
                        }

                        return await this.Context.Set<TenantVariable>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TenantVariable>();
                }

                private async Task<List<TenantVariable>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TenantVariable.Id)} ASC";
                        }

                        return await this.Context.Set<TenantVariable>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<TenantVariable>();
                }

                private async Task<TenantVariable> GetById(string id)
                {
                        List<TenantVariable> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>5e686119637061b20c32a2a85ff6ddf8</Hash>
</Codenesium>*/