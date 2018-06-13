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
        public abstract class AbstractEmployeeRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEmployeeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Employee> Get(int businessEntityID)
                {
                        return await this.GetById(businessEntityID);
                }

                public async virtual Task<Employee> Create(Employee item)
                {
                        this.Context.Set<Employee>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Employee item)
                {
                        var entity = this.Context.Set<Employee>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
                        if (entity == null)
                        {
                                this.Context.Set<Employee>().Attach(item);
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
                        Employee record = await this.GetById(businessEntityID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Employee>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Employee> GetLoginID(string loginID)
                {
                        var records = await this.SearchLinqEF(x => x.LoginID == loginID);

                        return records.FirstOrDefault();
                }
                public async Task<Employee> GetNationalIDNumber(string nationalIDNumber)
                {
                        var records = await this.SearchLinqEF(x => x.NationalIDNumber == nationalIDNumber);

                        return records.FirstOrDefault();
                }
                public async Task<List<Employee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel, Nullable<Guid> organizationNode)
                {
                        var records = await this.SearchLinqEF(x => x.OrganizationLevel == organizationLevel && x.OrganizationNode == organizationNode);

                        return records;
                }
                public async Task<List<Employee>> GetOrganizationNode(Nullable<Guid> organizationNode)
                {
                        var records = await this.SearchLinqEF(x => x.OrganizationNode == organizationNode);

                        return records;
                }

                protected async Task<List<Employee>> Where(Expression<Func<Employee, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Employee> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Employee>> SearchLinqEF(Expression<Func<Employee, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Employee.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Employee>();
                }

                private async Task<List<Employee>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Employee.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Employee>();
                }

                private async Task<Employee> GetById(int businessEntityID)
                {
                        List<Employee> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<EmployeeDepartmentHistory>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<EmployeeDepartmentHistory>();
                }
                public async virtual Task<List<EmployeePayHistory>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<EmployeePayHistory>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<EmployeePayHistory>();
                }
                public async virtual Task<List<JobCandidate>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<JobCandidate>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<JobCandidate>();
                }
        }
}

/*<Codenesium>
    <Hash>984ae7548706365e00542b49aec9758a</Hash>
</Codenesium>*/