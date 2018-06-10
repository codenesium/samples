using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public abstract class AbstractVenueRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractVenueRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Venue>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Venue> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Venue> Create(Venue item)
                {
                        this.Context.Set<Venue>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Venue item)
                {
                        var entity = this.Context.Set<Venue>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Venue>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int id)
                {
                        Venue record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Venue>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Venue>> GetAdminId(int adminId)
                {
                        var records = await this.SearchLinqEF(x => x.AdminId == adminId);

                        return records;
                }
                public async Task<List<Venue>> GetProvinceId(int provinceId)
                {
                        var records = await this.SearchLinqEF(x => x.ProvinceId == provinceId);

                        return records;
                }

                protected async Task<List<Venue>> Where(Expression<Func<Venue, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Venue> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Venue>> SearchLinqEF(Expression<Func<Venue, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Venue.Id)} ASC";
                        }

                        return await this.Context.Set<Venue>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Venue>();
                }

                private async Task<List<Venue>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Venue.Id)} ASC";
                        }

                        return await this.Context.Set<Venue>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Venue>();
                }

                private async Task<Venue> GetById(int id)
                {
                        List<Venue> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>4ed36d29a0bc468fe2aef2c676ab07b3</Hash>
</Codenesium>*/