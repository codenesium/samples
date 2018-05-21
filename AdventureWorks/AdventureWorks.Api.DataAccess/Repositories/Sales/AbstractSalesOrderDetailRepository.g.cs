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
	public abstract class AbstractSalesOrderDetailRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesOrderDetailRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesOrderDetail> Get(int salesOrderID)
		{
			SalesOrderDetail record = await this.GetById(salesOrderID);

			return this.Mapper.SalesOrderDetailMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesOrderDetail> Create(
			ApiSalesOrderDetailModel model)
		{
			SalesOrderDetail record = new SalesOrderDetail();

			this.Mapper.SalesOrderDetailMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesOrderDetail>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesOrderDetailMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int salesOrderID,
			ApiSalesOrderDetailModel model)
		{
			SalesOrderDetail record = await this.GetById(salesOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.SalesOrderDetailMapModelToEF(
					salesOrderID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int salesOrderID)
		{
			SalesOrderDetail record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderDetail>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOSalesOrderDetail>> GetProductID(int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<POCOSalesOrderDetail>> Where(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderDetail> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesOrderDetail>> SearchLinqPOCO(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderDetail> response = new List<POCOSalesOrderDetail>();
			List<SalesOrderDetail> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesOrderDetailMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SalesOrderDetail>> SearchLinqEF(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
			}
			return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderDetail>();
		}

		private async Task<List<SalesOrderDetail>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
			}

			return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderDetail>();
		}

		private async Task<SalesOrderDetail> GetById(int salesOrderID)
		{
			List<SalesOrderDetail> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>03a9ced16402d1eac0c3f70f6c485db8</Hash>
</Codenesium>*/