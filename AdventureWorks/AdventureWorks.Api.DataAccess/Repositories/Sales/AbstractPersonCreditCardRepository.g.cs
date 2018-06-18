using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractPersonCreditCardRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPersonCreditCardRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PersonCreditCard>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<PersonCreditCard> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<PersonCreditCard> Create(PersonCreditCard item)
                {
                        this.Context.Set<PersonCreditCard>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PersonCreditCard item)
                {
                        var entity = this.Context.Set<PersonCreditCard>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<PersonCreditCard>().Attach(item);
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
                        PersonCreditCard record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PersonCreditCard>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<PersonCreditCard>> Where(
                        Expression<Func<PersonCreditCard, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<PersonCreditCard, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PersonCreditCard>();
                        }
                        else
                        {
                                return await this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PersonCreditCard>();
                        }
                }

                private async Task<PersonCreditCard> GetById(int businessEntityID)
                {
                        List<PersonCreditCard> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<CreditCard> GetCreditCard(int creditCardID)
                {
                        return await this.Context.Set<CreditCard>().SingleOrDefaultAsync(x => x.CreditCardID == creditCardID);
                }
        }
}

/*<Codenesium>
    <Hash>85d6806860b0c13c009270155bfdf32d</Hash>
</Codenesium>*/