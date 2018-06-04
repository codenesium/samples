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

		public virtual Task<List<EmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		protected async Task<List<EmployeePayHistory>> Where(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EmployeePayHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<EmployeePayHistory>> SearchLinqEF(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeePayHistory.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeePayHistory>();
		}

		private async Task<List<EmployeePayHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeePayHistory.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeePayHistory>();
		}

		private async Task<EmployeePayHistory> GetById(int businessEntityID)
		{
			List<EmployeePayHistory> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c42fec33a0bcac8d3f4e3d8b81097125</Hash>
</Codenesium>*/