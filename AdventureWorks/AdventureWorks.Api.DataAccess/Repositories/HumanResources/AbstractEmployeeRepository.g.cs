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

		public virtual Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BirthDate == query.ToDateTime() ||
				                  x.BusinessEntityID == query.ToInt() ||
				                  x.CurrentFlag == query.ToBoolean() ||
				                  x.Gender.StartsWith(query) ||
				                  x.HireDate == query.ToDateTime() ||
				                  x.JobTitle.StartsWith(query) ||
				                  x.LoginID.StartsWith(query) ||
				                  x.MaritalStatu.StartsWith(query) ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.NationalIDNumber.StartsWith(query) ||
				                  x.OrganizationLevel == query.ToNullableShort() ||
				                  x.Rowguid == query.ToGuid() ||
				                  x.SalariedFlag == query.ToBoolean() ||
				                  x.SickLeaveHour == query.ToShort() ||
				                  x.VacationHour == query.ToShort(),
				                  limit,
				                  offset);
			}
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

		// unique constraint AK_Employee_LoginID.
		public async virtual Task<Employee> ByLoginID(string loginID)
		{
			return await this.Context.Set<Employee>().FirstOrDefaultAsync(x => x.LoginID == loginID);
		}

		// unique constraint AK_Employee_NationalIDNumber.
		public async virtual Task<Employee> ByNationalIDNumber(string nationalIDNumber)
		{
			return await this.Context.Set<Employee>().FirstOrDefaultAsync(x => x.NationalIDNumber == nationalIDNumber);
		}

		// unique constraint AK_Employee_rowguid.
		public async virtual Task<Employee> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<Employee>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Foreign key reference to this table JobCandidate via businessEntityID.
		public async virtual Task<List<JobCandidate>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<JobCandidate>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<JobCandidate>();
		}

		protected async Task<List<Employee>> Where(
			Expression<Func<Employee, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Employee, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Employee>();
		}

		private async Task<Employee> GetById(int businessEntityID)
		{
			List<Employee> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e65a915cb8c0986e2366253cc64d2cff</Hash>
</Codenesium>*/