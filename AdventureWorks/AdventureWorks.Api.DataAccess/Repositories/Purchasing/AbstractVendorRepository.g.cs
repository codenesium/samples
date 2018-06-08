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
        public abstract class AbstractVendorRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractVendorRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Vendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Vendor> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<Vendor> Create(Vendor item)
                {
                        this.Context.Set<Vendor>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Vendor item)
                {
                        var entity = this.Context.Set<Vendor>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<Vendor>().Attach(item);
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
                        Vendor record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Vendor>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Vendor> GetAccountNumber(string accountNumber)
                {
                        var records = await this.SearchLinqEF(x => x.AccountNumber == accountNumber);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Vendor>> Where(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Vendor> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Vendor>> SearchLinqEF(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Vendor.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Vendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Vendor>();
                }

                private async Task<List<Vendor>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Vendor.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Vendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Vendor>();
                }

                private async Task<Vendor> GetById(int businessEntityID)
                {
                        List<Vendor> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>88ddba3e32eee0ace819278e4a7ef0b8</Hash>
</Codenesium>*/