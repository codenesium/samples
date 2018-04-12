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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesOrderDetailRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int salesOrderDetailID,
			string carrierTrackingNumber,
			short orderQty,
			int productID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount,
			decimal lineTotal,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = new EFSalesOrderDetail();

			MapPOCOToEF(
				0,
				salesOrderDetailID,
				carrierTrackingNumber,
				orderQty,
				productID,
				specialOfferID,
				unitPrice,
				unitPriceDiscount,
				lineTotal,
				rowguid,
				modifiedDate,
				record);

			this.context.Set<EFSalesOrderDetail>().Add(record);
			this.context.SaveChanges();
			return record.SalesOrderID;
		}

		public virtual void Update(
			int salesOrderID,
			int salesOrderDetailID,
			string carrierTrackingNumber,
			short orderQty,
			int productID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount,
			decimal lineTotal,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesOrderID}");
			}
			else
			{
				MapPOCOToEF(
					salesOrderID,
					salesOrderDetailID,
					carrierTrackingNumber,
					orderQty,
					productID,
					specialOfferID,
					unitPrice,
					unitPriceDiscount,
					lineTotal,
					rowguid,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesOrderID)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesOrderDetail>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int salesOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID, response);
			return response;
		}

		public virtual POCOSalesOrderDetail GetByIdDirect(int salesOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID, response);
			return response.SalesOrderDetails.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOSalesOrderDetail> GetWhereDirect(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesOrderDetails;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesOrderDetail, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesOrderDetail> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesOrderDetail> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesOrderDetail> SearchLinqEF(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderDetail> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int salesOrderID,
			int salesOrderDetailID,
			string carrierTrackingNumber,
			short orderQty,
			int productID,
			int specialOfferID,
			decimal unitPrice,
			decimal unitPriceDiscount,
			decimal lineTotal,
			Guid rowguid,
			DateTime modifiedDate,
			EFSalesOrderDetail efSalesOrderDetail)
		{
			efSalesOrderDetail.SetProperties(salesOrderID.ToInt(), salesOrderDetailID.ToInt(), carrierTrackingNumber, orderQty, productID.ToInt(), specialOfferID.ToInt(), unitPrice, unitPriceDiscount, lineTotal.ToDecimal(), rowguid, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFSalesOrderDetail efSalesOrderDetail,
			Response response)
		{
			if (efSalesOrderDetail == null)
			{
				return;
			}

			response.AddSalesOrderDetail(new POCOSalesOrderDetail(efSalesOrderDetail.SalesOrderID.ToInt(), efSalesOrderDetail.SalesOrderDetailID.ToInt(), efSalesOrderDetail.CarrierTrackingNumber, efSalesOrderDetail.OrderQty, efSalesOrderDetail.ProductID.ToInt(), efSalesOrderDetail.SpecialOfferID.ToInt(), efSalesOrderDetail.UnitPrice, efSalesOrderDetail.UnitPriceDiscount, efSalesOrderDetail.LineTotal.ToDecimal(), efSalesOrderDetail.Rowguid, efSalesOrderDetail.ModifiedDate.ToDateTime()));

			SalesOrderHeaderRepository.MapEFToPOCO(efSalesOrderDetail.SalesOrderHeader, response);

			SpecialOfferProductRepository.MapEFToPOCO(efSalesOrderDetail.SpecialOfferProduct, response);
		}
	}
}

/*<Codenesium>
    <Hash>e5fd4d8966afb424eac1d30c2c51aee7</Hash>
</Codenesium>*/