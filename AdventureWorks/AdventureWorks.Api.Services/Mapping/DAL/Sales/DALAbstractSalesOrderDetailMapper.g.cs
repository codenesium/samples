using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesOrderDetailMapper
	{
		public virtual SalesOrderDetail MapBOToEF(
			BOSalesOrderDetail bo)
		{
			SalesOrderDetail efSalesOrderDetail = new SalesOrderDetail ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>8d2231002589822db62f19736098582a</Hash>
</Codenesium>*/