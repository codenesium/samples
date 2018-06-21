using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractSpecialOfferRepository : AbstractRepository
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

                public virtual Task<List<SpecialOffer>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async virtual Task<List<SpecialOfferProduct>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SpecialOfferProduct>().Where(x => x.SpecialOfferID == specialOfferID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpecialOfferProduct>();
                }

                protected async Task<List<SpecialOffer>> Where(
                        Expression<Func<SpecialOffer, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<SpecialOffer, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.SpecialOfferID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpecialOffer>();
                        }
                        else
                        {
                                return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SpecialOffer>();
                        }
                }

                private async Task<SpecialOffer> GetById(int specialOfferID)
                {
                        List<SpecialOffer> records = await this.Where(x => x.SpecialOfferID == specialOfferID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>318fe3ed6a9ab81e2260f22bb9016e21</Hash>
</Codenesium>*/