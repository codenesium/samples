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

                public virtual Task<List<SpecialOffer>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<SpecialOffer>> Where(Expression<Func<SpecialOffer, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<SpecialOffer> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<SpecialOffer>> SearchLinqEF(Expression<Func<SpecialOffer, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
                        }

                        return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SpecialOffer>();
                }

                private async Task<List<SpecialOffer>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
                        }

                        return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<SpecialOffer>();
                }

                private async Task<SpecialOffer> GetById(int specialOfferID)
                {
                        List<SpecialOffer> records = await this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<SpecialOfferProduct>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SpecialOfferProduct>().Where(x => x.SpecialOfferID == specialOfferID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpecialOfferProduct>();
                }
        }
}

/*<Codenesium>
    <Hash>cf33187c71f0f77f05b6eea8b3aa547e</Hash>
</Codenesium>*/