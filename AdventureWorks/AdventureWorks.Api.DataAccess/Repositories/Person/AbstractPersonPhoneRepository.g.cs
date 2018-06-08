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
        public abstract class AbstractPersonPhoneRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPersonPhoneRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PersonPhone>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<PersonPhone> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<PersonPhone> Create(PersonPhone item)
                {
                        this.Context.Set<PersonPhone>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PersonPhone item)
                {
                        var entity = this.Context.Set<PersonPhone>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<PersonPhone>().Attach(item);
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
                        PersonPhone record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PersonPhone>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<PersonPhone>> GetPhoneNumber(string phoneNumber)
                {
                        var records = await this.SearchLinqEF(x => x.PhoneNumber == phoneNumber);

                        return records;
                }

                protected async Task<List<PersonPhone>> Where(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<PersonPhone> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<PersonPhone>> SearchLinqEF(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonPhone>();
                }

                private async Task<List<PersonPhone>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonPhone>();
                }

                private async Task<PersonPhone> GetById(int businessEntityID)
                {
                        List<PersonPhone> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>eafd6ef03437fc1bca563f12b8b71fdf</Hash>
</Codenesium>*/