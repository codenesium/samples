using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesOrderDetailMapper
	{
		public virtual BOSalesOrderDetail MapModelToBO(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel model
			)
		{
			BOSalesOrderDetail BOSalesOrderDetail = new BOSalesOrderDetail();

			BOSalesOrderDetail.SetProperties(
				salesOrderID,
				model.CarrierTrackingNumber,
				model.LineTotal,
				model.ModifiedDate,
				model.OrderQty,
				model.ProductID,
				model.Rowguid,
				model.SalesOrderDetailID,
				model.SpecialOfferID,
				model.UnitPrice,
				model.UnitPriceDiscount);
			return BOSalesOrderDetail;
		}

		public virtual ApiSalesOrderDetailResponseModel MapBOToModel(
			BOSalesOrderDetail BOSalesOrderDetail)
		{
			if (BOSalesOrderDetail == null)
			{
				return null;
			}

			var model = new ApiSalesOrderDetailResponseModel();

			model.SetProperties(BOSalesOrderDetail.CarrierTrackingNumber, BOSalesOrderDetail.LineTotal, BOSalesOrderDetail.ModifiedDate, BOSalesOrderDetail.OrderQty, BOSalesOrderDetail.ProductID, BOSalesOrderDetail.Rowguid, BOSalesOrderDetail.SalesOrderDetailID, BOSalesOrderDetail.SalesOrderID, BOSalesOrderDetail.SpecialOfferID, BOSalesOrderDetail.UnitPrice, BOSalesOrderDetail.UnitPriceDiscount);

			return model;
		}

		public virtual List<ApiSalesOrderDetailResponseModel> MapBOToModel(
			List<BOSalesOrderDetail> BOs)
		{
			List<ApiSalesOrderDetailResponseModel> response = new List<ApiSalesOrderDetailResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ff5fc55e960db46a67ca211e16fbc27e</Hash>
</Codenesium>*/