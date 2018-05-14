using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractPurchaseOrderDetailRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPurchaseOrderDetailRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPurchaseOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPurchaseOrderDetail Get(int purchaseOrderID)
		{
			return this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
		}

		public virtual POCOPurchaseOrderDetail Create(
			ApiPurchaseOrderDetailModel model)
		{
			PurchaseOrderDetail record = new PurchaseOrderDetail();

			this.Mapper.PurchaseOrderDetailMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PurchaseOrderDetail>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PurchaseOrderDetailMapEFToPOCO(record);
		}

		public virtual void Update(
			int purchaseOrderID,
			ApiPurchaseOrderDetailModel model)
		{
			PurchaseOrderDetail record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int purchaseOrderID)
		{
			PurchaseOrderDetail record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PurchaseOrderDetail>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOPurchaseOrderDetail> GetProductID(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		protected List<POCOPurchaseOrderDetail> Where(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPurchaseOrderDetail> SearchLinqPOCO(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPurchaseOrderDetail> response = new List<POCOPurchaseOrderDetail>();
			List<PurchaseOrderDetail> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PurchaseOrderDetailMapEFToPOCO(x)));
			return response;
		}

		private List<PurchaseOrderDetail> SearchLinqEF(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
			}
			return this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PurchaseOrderDetail>();
		}

		private List<PurchaseOrderDetail> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
			}

			return this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PurchaseOrderDetail>();
		}
	}
}

/*<Codenesium>
    <Hash>bfb557c9064112f4410f7f64b5108957</Hash>
</Codenesium>*/