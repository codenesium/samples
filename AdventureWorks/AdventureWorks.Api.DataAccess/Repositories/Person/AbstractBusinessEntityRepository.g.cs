using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractBusinessEntityRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractBusinessEntityRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<BusinessEntity>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<BusinessEntity> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<BusinessEntity> Create(BusinessEntity item)
                {
                        this.Context.Set<BusinessEntity>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(BusinessEntity item)
                {
                        var entity = this.Context.Set<BusinessEntity>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<BusinessEntity>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int businessEntityID)
                {
                        BusinessEntity record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<BusinessEntity>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<BusinessEntity>> Where(Expression<Func<BusinessEntity, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<BusinessEntity> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<BusinessEntity>> SearchLinqEF(Expression<Func<BusinessEntity, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(BusinessEntity.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<BusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<BusinessEntity>();
                }

                private async Task<List<BusinessEntity>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(BusinessEntity.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<BusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<BusinessEntity>();
                }

                private async Task<BusinessEntity> GetById(int businessEntityID)
                {
                        List<BusinessEntity> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<BusinessEntityAddress>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BusinessEntityAddress>();
                }
                public async virtual Task<List<BusinessEntityContact>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<BusinessEntityContact>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BusinessEntityContact>();
                }
                public async virtual Task<List<Person>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Person>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Person>();
                }
        }
}

/*<Codenesium>
    <Hash>e341995f94b274230e847adbba9dc54c</Hash>
</Codenesium>*/