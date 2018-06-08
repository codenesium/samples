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
        public abstract class AbstractSpecialOfferRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSpecialOfferRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<SpecialOffer> Get(int specialOfferID)
                {
                        return await this.GetById(specialOfferID);
                }

                public async virtual Task<SpecialOffer> Create(SpecialOffer item)
                {
                        this.Context.Set<SpecialOffer>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SpecialOffer item)
                {
                        var entity = this.Context.Set<SpecialOffer>().Local.FirstOrDefault(x => x.SpecialOfferID == item.SpecialOfferID);
                        if (entity == null)
                        {
                                this.Context.Set<SpecialOffer>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int specialOfferID)
                {
                        SpecialOffer record = await this.GetById(specialOfferID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SpecialOffer>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<SpecialOffer>> Where(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<SpecialOffer> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<SpecialOffer>> SearchLinqEF(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
                        }

                        return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOffer>();
                }

                private async Task<List<SpecialOffer>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
                        }

                        return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOffer>();
                }

                private async Task<SpecialOffer> GetById(int specialOfferID)
                {
                        List<SpecialOffer> records = await this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>98978ac11699658a6c13bfedddf5cd41</Hash>
</Codenesium>*/