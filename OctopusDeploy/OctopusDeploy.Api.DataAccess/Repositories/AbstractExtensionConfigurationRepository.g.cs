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
        public abstract class AbstractExtensionConfigurationRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractExtensionConfigurationRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ExtensionConfiguration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<ExtensionConfiguration> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ExtensionConfiguration> Create(ExtensionConfiguration item)
                {
                        this.Context.Set<ExtensionConfiguration>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ExtensionConfiguration item)
                {
                        var entity = this.Context.Set<ExtensionConfiguration>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ExtensionConfiguration>().Attach(item);
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
                        ExtensionConfiguration record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ExtensionConfiguration>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<ExtensionConfiguration>> Where(Expression<Func<ExtensionConfiguration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ExtensionConfiguration> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ExtensionConfiguration>> SearchLinqEF(Expression<Func<ExtensionConfiguration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ExtensionConfiguration.Id)} ASC";
                        }

                        return await this.Context.Set<ExtensionConfiguration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ExtensionConfiguration>();
                }

                private async Task<List<ExtensionConfiguration>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ExtensionConfiguration.Id)} ASC";
                        }

                        return await this.Context.Set<ExtensionConfiguration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ExtensionConfiguration>();
                }

                private async Task<ExtensionConfiguration> GetById(string id)
                {
                        List<ExtensionConfiguration> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>c0284cb15cd28a8a9e64b10a1ee1c8b0</Hash>
</Codenesium>*/