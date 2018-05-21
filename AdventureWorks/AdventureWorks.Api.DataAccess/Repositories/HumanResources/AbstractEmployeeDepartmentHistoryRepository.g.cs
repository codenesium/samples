using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractEmployeeDepartmentHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmployeeDepartmentHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOEmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOEmployeeDepartmentHistory> Get(int businessEntityID)
		{
			EmployeeDepartmentHistory record = await this.GetById(businessEntityID);

			return this.Mapper.EmployeeDepartmentHistoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOEmployeeDepartmentHistory> Create(
			ApiEmployeeDepartmentHistoryModel model)
		{
			EmployeeDepartmentHistory record = new EmployeeDepartmentHistory();

			this.Mapper.EmployeeDepartmentHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EmployeeDepartmentHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.EmployeeDepartmentHistoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryModel model)
		{
			EmployeeDepartmentHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.EmployeeDepartmentHistoryMapModelToEF(
					businessEntityID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		public async Task<List<POCOEmployeeDepartmentHistory>> GetDepartmentID(short departmentID)
		{
			var records = await this.SearchLinqPOCO(x => x.DepartmentID == departmentID);

			return records;
		}
		public async Task<List<POCOEmployeeDepartmentHistory>> GetShiftID(int shiftID)
		{
			var records = await this.SearchLinqPOCO(x => x.ShiftID == shiftID);

			return records;
		}

		protected async Task<List<POCOEmployeeDepartmentHistory>> Where(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployeeDepartmentHistory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOEmployeeDepartmentHistory>> SearchLinqPOCO(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployeeDepartmentHistory> response = new List<POCOEmployeeDepartmentHistory>();
			List<EmployeeDepartmentHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.EmployeeDepartmentHistoryMapEFToPOCO(x)));
			return response;
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
    <Hash>0b3306acf7dcbbdbcc6b7a609b311469</Hash>
</Codenesium>*/