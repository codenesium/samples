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
	public abstract class AbstractSalesOrderHeaderRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesOrderHeaderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesOrderHeader> Get(int salesOrderID)
		{
			SalesOrderHeader record = await this.GetById(salesOrderID);

			return this.Mapper.SalesOrderHeaderMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesOrderHeader> Create(
			ApiSalesOrderHeaderModel model)
		{
			SalesOrderHeader record = new SalesOrderHeader();

			this.Mapper.SalesOrderHeaderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesOrderHeader>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesOrderHeaderMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int salesOrderID,
			ApiSalesOrderHeaderModel model)
		{
			SalesOrderHeader record = await this.GetById(salesOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.SalesOrderHeaderMapModelToEF(
					salesOrderID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int salesOrderID)
		{
			SalesOrderHeader record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderHeader>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOSalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber)
		{
			var records = await this.SearchLinqPOCO(x => x.SalesOrderNumber == salesOrderNumber);

			return records.FirstOrDefault();
		}
		public async Task<List<POCOSalesOrderHeader>> GetCustomerID(int customerID)
		{
			var records = await this.SearchLinqPOCO(x => x.CustomerID == customerID);

			return records;
		}
		public async Task<List<POCOSalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			var records = await this.SearchLinqPOCO(x => x.SalesPersonID == salesPersonID);

			return records;
		}

		protected async Task<List<POCOSalesOrderHeader>> Where(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderHeader> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesOrderHeader>> SearchLinqPOCO(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderHeader> response = new List<POCOSalesOrderHeader>();
			List<SalesOrderHeader> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesOrderHeaderMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SalesOrderHeader>> SearchLinqEF(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
			}
			return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeader>();
		}

		private async Task<List<SalesOrderHeader>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
			}

			return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeader>();
		}

		private async Task<SalesOrderHeader> GetById(int salesOrderID)
		{
			List<SalesOrderHeader> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>646ccaccc1cc3dbcc5b3af5baa8959e9</Hash>
</Codenesium>*/