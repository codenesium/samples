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
        public abstract class AbstractEmployeeDepartmentHistoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEmployeeDepartmentHistoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<EmployeeDepartmentHistory>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<EmployeeDepartmentHistory> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<EmployeeDepartmentHistory> Create(EmployeeDepartmentHistory item)
                {
                        this.Context.Set<EmployeeDepartmentHistory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(EmployeeDepartmentHistory item)
                {
                        var entity = this.Context.Set<EmployeeDepartmentHistory>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<EmployeeDepartmentHistory>().Attach(item);
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
                        EmployeeDepartmentHistory record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<EmployeeDepartmentHistory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<EmployeeDepartmentHistory>> ByDepartmentID(short departmentID)
                {
                        var records = await this.Where(x => x.DepartmentID == departmentID);

                        return records;
                }
                public async Task<List<EmployeeDepartmentHistory>> ByShiftID(int shiftID)
                {
                        var records = await this.Where(x => x.ShiftID == shiftID);

                        return records;
                }

                protected async Task<List<EmployeeDepartmentHistory>> Where(
                        Expression<Func<EmployeeDepartmentHistory, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<EmployeeDepartmentHistory, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.BusinessEntityID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EmployeeDepartmentHistory>();
                        }
                        else
                        {
                                return await this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<EmployeeDepartmentHistory>();
                        }
                }

                private async Task<EmployeeDepartmentHistory> GetById(int businessEntityID)
                {
                        List<EmployeeDepartmentHistory> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>f48a3e63a22d594e48d8f93d8682ddae</Hash>
</Codenesium>*/