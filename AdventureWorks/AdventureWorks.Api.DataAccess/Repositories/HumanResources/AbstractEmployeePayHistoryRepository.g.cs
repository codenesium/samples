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
        public abstract class AbstractEmployeePayHistoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEmployeePayHistoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<EmployeePayHistory>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<EmployeePayHistory> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<EmployeePayHistory> Create(EmployeePayHistory item)
                {
                        this.Context.Set<EmployeePayHistory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(EmployeePayHistory item)
                {
                        var entity = this.Context.Set<EmployeePayHistory>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<EmployeePayHistory>().Attach(item);
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
                        EmployeePayHistory record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<EmployeePayHistory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<EmployeePayHistory>> Where(
                        Expression<Func<EmployeePayHistory, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<EmployeePayHistory, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EmployeePayHistory>();
                        }
                        else
                        {
                                return await this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<EmployeePayHistory>();
                        }
                }

                private async Task<EmployeePayHistory> GetById(int businessEntityID)
                {
                        List<EmployeePayHistory> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>6f55fe32383cf44b516aa5ae4b23fddb</Hash>
</Codenesium>*/