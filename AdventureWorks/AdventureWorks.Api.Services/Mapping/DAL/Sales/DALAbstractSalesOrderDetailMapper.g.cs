using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSalesOrderDetailMapper
	{
		public virtual SalesOrderDetail MapBOToEF(
			BOSalesOrderDetail bo)
		{
			SalesOrderDetail efSalesOrderDetail = new SalesOrderDetail();
			efSalesOrderDetail.SetProperties(
				bo.CarrierTrackingNumber,
				bo.LineTotal,
				bo.ModifiedDate,
				bo.OrderQty,
				bo.ProductID,
				bo.Rowguid,
				bo.SalesOrderDetailID,
				bo.SalesOrderID,
				bo.SpecialOfferID,
				bo.UnitPrice,
				bo.UnitPriceDiscount);
			return efSalesOrderDetail;
		}

		public virtual BOSalesOrderDetail MapEFToBO(
			SalesOrderDetail ef)
		{
			var bo = new BOSalesOrderDetail();

			bo.SetProperties(
				ef.SalesOrderID,
				ef.CarrierTrackingNumber,
				ef.LineTotal,
				ef.ModifiedDate,
				ef.OrderQty,
				ef.ProductID,
				ef.Rowguid,
				ef.SalesOrderDetailID,
				ef.SpecialOfferID,
				ef.UnitPrice,
				ef.UnitPriceDiscount);
			return bo;
		}

		public virtual List<BOSalesOrderDetail> MapEFToBO(
			List<SalesOrderDetail> records)
		{
			List<BOSalesOrderDetail> response = new List<BOSalesOrderDetail>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e40bc5f83659a1aeac2ff949fa34e525</Hash>
</Codenesium>*/