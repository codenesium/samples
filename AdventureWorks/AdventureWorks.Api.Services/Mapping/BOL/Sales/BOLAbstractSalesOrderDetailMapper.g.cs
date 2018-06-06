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
			BOSalesOrderDetail boSalesOrderDetail = new BOSalesOrderDetail();

			boSalesOrderDetail.SetProperties(
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
			return boSalesOrderDetail;
		}

		public virtual ApiSalesOrderDetailResponseModel MapBOToModel(
			BOSalesOrderDetail boSalesOrderDetail)
		{
			var model = new ApiSalesOrderDetailResponseModel();

			model.SetProperties(boSalesOrderDetail.CarrierTrackingNumber, boSalesOrderDetail.LineTotal, boSalesOrderDetail.ModifiedDate, boSalesOrderDetail.OrderQty, boSalesOrderDetail.ProductID, boSalesOrderDetail.Rowguid, boSalesOrderDetail.SalesOrderDetailID, boSalesOrderDetail.SalesOrderID, boSalesOrderDetail.SpecialOfferID, boSalesOrderDetail.UnitPrice, boSalesOrderDetail.UnitPriceDiscount);

			return model;
		}

		public virtual List<ApiSalesOrderDetailResponseModel> MapBOToModel(
			List<BOSalesOrderDetail> items)
		{
			List<ApiSalesOrderDetailResponseModel> response = new List<ApiSalesOrderDetailResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>28346d4b8c64ddcab42af83ce9e7465e</Hash>
</Codenesium>*/