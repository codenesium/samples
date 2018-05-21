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
	public abstract class AbstractPurchaseOrderDetailRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPurchaseOrderDetailRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPurchaseOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPurchaseOrderDetail> Get(int purchaseOrderID)
		{
			PurchaseOrderDetail record = await this.GetById(purchaseOrderID);

			return this.Mapper.PurchaseOrderDetailMapEFToPOCO(record);
		}

		public async virtual Task<POCOPurchaseOrderDetail> Create(
			ApiPurchaseOrderDetailModel model)
		{
			PurchaseOrderDetail record = new PurchaseOrderDetail();

			this.Mapper.PurchaseOrderDetailMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PurchaseOrderDetail>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PurchaseOrderDetailMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int purchaseOrderID,
			ApiPurchaseOrderDetailModel model)
		{
			PurchaseOrderDetail record = await this.GetById(purchaseOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{purchaseOrderID}");
			}
			else
			{
				this.Mapper.PurchaseOrderDetailMapModelToEF(
					purchaseOrderID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int purchaseOrderID)
		{
			PurchaseOrderDetail record = await this.GetById(purchaseOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PurchaseOrderDetail>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOPurchaseOrderDetail>> GetProductID(int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<POCOPurchaseOrderDetail>> Where(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPurchaseOrderDetail> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPurchaseOrderDetail>> SearchLinqPOCO(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPurchaseOrderDetail> response = new List<POCOPurchaseOrderDetail>();
			List<PurchaseOrderDetail> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PurchaseOrderDetailMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PurchaseOrderDetail>> SearchLinqEF(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
			}
			return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PurchaseOrderDetail>();
		}

		private async Task<List<PurchaseOrderDetail>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
			}

			return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PurchaseOrderDetail>();
		}

		private async Task<PurchaseOrderDetail> GetById(int purchaseOrderID)
		{
			List<PurchaseOrderDetail> records = await this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>318c4c4428216f650861aa47ca7210cd</Hash>
</Codenesium>*/