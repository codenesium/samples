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

		public virtual Task<List<EmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<List<EmployeeDepartmentHistory>> GetDepartmentID(short departmentID)
		{
			var records = await this.SearchLinqEF(x => x.DepartmentID == departmentID);

			return records;
		}
		public async Task<List<EmployeeDepartmentHistory>> GetShiftID(int shiftID)
		{
			var records = await this.SearchLinqEF(x => x.ShiftID == shiftID);

			return records;
		}

		protected async Task<List<EmployeeDepartmentHistory>> Where(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EmployeeDepartmentHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<EmployeeDepartmentHistory>> SearchLinqEF(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeeDepartmentHistory.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeeDepartmentHistory>();
		}

		private async Task<List<EmployeeDepartmentHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeeDepartmentHistory.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeeDepartmentHistory>();
		}

		private async Task<EmployeeDepartmentHistory> GetById(int businessEntityID)
		{
			List<EmployeeDepartmentHistory> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9275f20b95d2435df8542f4b83d687c5</Hash>
</Codenesium>*/