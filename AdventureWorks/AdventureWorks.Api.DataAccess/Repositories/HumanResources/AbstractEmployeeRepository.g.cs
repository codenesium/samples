using Codenesium.DataConversionExtensions;
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
	public abstract class AbstractEmployeeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEmployeeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<Employee> ByLoginID(string loginID)
		{
			return await this.Context.Set<Employee>().SingleOrDefaultAsync(x => x.LoginID == loginID);
		}

		public async Task<Employee> ByNationalIDNumber(string nationalIDNumber)
		{
			return await this.Context.Set<Employee>().SingleOrDefaultAsync(x => x.NationalIDNumber == nationalIDNumber);
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

		protected async Task<List<Employee>> Where(
			Expression<Func<Employee, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Employee, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Employee>();
			}
			else
			{
				return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Employee>();
			}
		}

		private async Task<Employee> GetById(int businessEntityID)
		{
			List<Employee> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2e9c9ca7b98cb7e3325cf13f337ec0f3</Hash>
</Codenesium>*/