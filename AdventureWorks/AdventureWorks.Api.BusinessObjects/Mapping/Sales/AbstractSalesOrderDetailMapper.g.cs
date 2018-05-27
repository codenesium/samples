using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesOrderDetailMapper
	{
		public virtual DTOSalesOrderDetail MapModelToDTO(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel model
			)
		{
			DTOSalesOrderDetail dtoSalesOrderDetail = new DTOSalesOrderDetail();

			dtoSalesOrderDetail.SetProperties(
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
			return dtoSalesOrderDetail;
		}

		public virtual ApiSalesOrderDetailResponseModel MapDTOToModel(
			DTOSalesOrderDetail dtoSalesOrderDetail)
		{
			if (dtoSalesOrderDetail == null)
			{
				return null;
			}

			var model = new ApiSalesOrderDetailResponseModel();

			model.SetProperties(dtoSalesOrderDetail.CarrierTrackingNumber, dtoSalesOrderDetail.LineTotal, dtoSalesOrderDetail.ModifiedDate, dtoSalesOrderDetail.OrderQty, dtoSalesOrderDetail.ProductID, dtoSalesOrderDetail.Rowguid, dtoSalesOrderDetail.SalesOrderDetailID, dtoSalesOrderDetail.SalesOrderID, dtoSalesOrderDetail.SpecialOfferID, dtoSalesOrderDetail.UnitPrice, dtoSalesOrderDetail.UnitPriceDiscount);

			return model;
		}

		public virtual List<ApiSalesOrderDetailResponseModel> MapDTOToModel(
			List<DTOSalesOrderDetail> dtos)
		{
			List<ApiSalesOrderDetailResponseModel> response = new List<ApiSalesOrderDetailResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fee051e41ae381517849f6c2179efd15</Hash>
</Codenesium>*/