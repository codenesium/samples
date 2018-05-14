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
	public abstract class AbstractSalesOrderDetailRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesOrderDetailRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSalesOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesOrderDetail Get(int salesOrderID)
		{
			return this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
		}

		public virtual POCOSalesOrderDetail Create(
			ApiSalesOrderDetailModel model)
		{
			SalesOrderDetail record = new SalesOrderDetail();

			this.Mapper.SalesOrderDetailMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesOrderDetail>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesOrderDetailMapEFToPOCO(record);
		}

		public virtual void Update(
			int salesOrderID,
			ApiSalesOrderDetailModel model)
		{
			SalesOrderDetail record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesOrderID)
		{
			SalesOrderDetail record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderDetail>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOSalesOrderDetail> GetProductID(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		protected List<POCOSalesOrderDetail> Where(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesOrderDetail> SearchLinqPOCO(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderDetail> response = new List<POCOSalesOrderDetail>();
			List<SalesOrderDetail> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesOrderDetailMapEFToPOCO(x)));
			return response;
		}

		private List<SalesOrderDetail> SearchLinqEF(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
			}
			return this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesOrderDetail>();
		}

		private List<SalesOrderDetail> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
			}

			return this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesOrderDetail>();
		}
	}
}

/*<Codenesium>
    <Hash>0285212cecf5ed9c2929879c625748e0</Hash>
</Codenesium>*/