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
	public abstract class AbstractEmployeePayHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmployeePayHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOEmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOEmployeePayHistory> Get(int businessEntityID)
		{
			EmployeePayHistory record = await this.GetById(businessEntityID);

			return this.Mapper.EmployeePayHistoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOEmployeePayHistory> Create(
			ApiEmployeePayHistoryModel model)
		{
			EmployeePayHistory record = new EmployeePayHistory();

			this.Mapper.EmployeePayHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EmployeePayHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.EmployeePayHistoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiEmployeePayHistoryModel model)
		{
			EmployeePayHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.EmployeePayHistoryMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOEmployeePayHistory>> Where(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployeePayHistory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOEmployeePayHistory>> SearchLinqPOCO(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployeePayHistory> response = new List<POCOEmployeePayHistory>();
			List<EmployeePayHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.EmployeePayHistoryMapEFToPOCO(x)));
			return response;
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
    <Hash>9b87f4fd859f0a22589e79c482b420dd</Hash>
</Codenesium>*/