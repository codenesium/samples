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

                public virtual Task<List<Employee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<Employee>> Where(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Employee> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Employee>> SearchLinqEF(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Employee.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Employee>();
                }

                private async Task<List<Employee>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Employee.BusinessEntityID)} ASC";
                        }

                        return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Employee>();
                }

                private async Task<Employee> GetById(int businessEntityID)
                {
                        List<Employee> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>6f20609d7f4d03715d197d048a48f346</Hash>
</Codenesium>*/