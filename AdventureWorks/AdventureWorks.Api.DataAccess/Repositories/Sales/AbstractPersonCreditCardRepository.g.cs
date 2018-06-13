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

                public virtual Task<List<PersonCreditCard>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<PersonCreditCard>> Where(Expression<Func<PersonCreditCard, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<PersonCreditCard> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<PersonCreditCard>> SearchLinqEF(Expression<Func<PersonCreditCard, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PersonCreditCard.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PersonCreditCard>();
                }

                private async Task<List<PersonCreditCard>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(PersonCreditCard.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<PersonCreditCard>();
                }

                private async Task<PersonCreditCard> GetById(int businessEntityID)
                {
                        List<PersonCreditCard> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ea3ce106a59affbf59c52b112d1d1aa1</Hash>
</Codenesium>*/