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
        public abstract class AbstractSalesOrderHeaderSalesReasonRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSalesOrderHeaderSalesReasonRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SalesOrderHeaderSalesReason>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<SalesOrderHeaderSalesReason> Get(int salesOrderID)
                {
                        return await this.GetById(salesOrderID);
                }

                public async virtual Task<SalesOrderHeaderSalesReason> Create(SalesOrderHeaderSalesReason item)
                {
                        this.Context.Set<SalesOrderHeaderSalesReason>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SalesOrderHeaderSalesReason item)
                {
                        var entity = this.Context.Set<SalesOrderHeaderSalesReason>().Local.FirstOrDefault(x => x.SalesOrderID == item.SalesOrderID);
                        if (entity == null)
                        {
                                this.Context.Set<SalesOrderHeaderSalesReason>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int salesOrderID)
                {
                        SalesOrderHeaderSalesReason record = await this.GetById(salesOrderID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SalesOrderHeaderSalesReason>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<SalesOrderHeader> GetSalesOrderHeader(int salesOrderID)
                {
                        return await this.Context.Set<SalesOrderHeader>().SingleOrDefaultAsync(x => x.SalesOrderID == salesOrderID);
                }

                public async virtual Task<SalesReason> GetSalesReason(int salesReasonID)
                {
                        return await this.Context.Set<SalesReason>().SingleOrDefaultAsync(x => x.SalesReasonID == salesReasonID);
                }

                protected async Task<List<SalesOrderHeaderSalesReason>> Where(
                        Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<SalesOrderHeaderSalesReason, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.SalesOrderID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesOrderHeaderSalesReason>();
                        }
                        else
                        {
                                return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SalesOrderHeaderSalesReason>();
                        }
                }

                private async Task<SalesOrderHeaderSalesReason> GetById(int salesOrderID)
                {
                        List<SalesOrderHeaderSalesReason> records = await this.Where(x => x.SalesOrderID == salesOrderID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ecc8606b1220eece9e642d2027b62bf4</Hash>
</Codenesium>*/