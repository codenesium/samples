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

                public virtual Task<List<TenantVariable>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<TenantVariable>> Where(Expression<Func<TenantVariable, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<TenantVariable> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<TenantVariable>> SearchLinqEF(Expression<Func<TenantVariable, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TenantVariable.Id)} ASC";
                        }

                        return await this.Context.Set<TenantVariable>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TenantVariable>();
                }

                private async Task<List<TenantVariable>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(TenantVariable.Id)} ASC";
                        }

                        return await this.Context.Set<TenantVariable>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TenantVariable>();
                }

                private async Task<TenantVariable> GetById(string id)
                {
                        List<TenantVariable> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>752ce9f255402fd5cd91be91210377e8</Hash>
</Codenesium>*/