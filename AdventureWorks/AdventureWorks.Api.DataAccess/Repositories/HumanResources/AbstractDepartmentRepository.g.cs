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
        public abstract class AbstractDepartmentRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDepartmentRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Department>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Department> Get(short departmentID)
                {
                        return await this.GetById(departmentID);
                }

                public async virtual Task<Department> Create(Department item)
                {
                        this.Context.Set<Department>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Department item)
                {
                        var entity = this.Context.Set<Department>().Local.FirstOrDefault(x => x.DepartmentID == item.DepartmentID);
                        if (entity == null)
                        {
                                this.Context.Set<Department>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        short departmentID)
                {
                        Department record = await this.GetById(departmentID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Department>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Department> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Department>> Where(Expression<Func<Department, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Department> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Department>> SearchLinqEF(Expression<Func<Department, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Department.DepartmentID)} ASC";
                        }

                        return await this.Context.Set<Department>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Department>();
                }

                private async Task<List<Department>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Department.DepartmentID)} ASC";
                        }

                        return await this.Context.Set<Department>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Department>();
                }

                private async Task<Department> GetById(short departmentID)
                {
                        List<Department> records = await this.SearchLinqEF(x => x.DepartmentID == departmentID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<EmployeeDepartmentHistory>().Where(x => x.DepartmentID == departmentID).AsQueryable().Skip(offset).Take(limit).ToListAsync<EmployeeDepartmentHistory>();
                }
        }
}

/*<Codenesium>
    <Hash>d3d802aec5f9176aeb873e49adebe38e</Hash>
</Codenesium>*/