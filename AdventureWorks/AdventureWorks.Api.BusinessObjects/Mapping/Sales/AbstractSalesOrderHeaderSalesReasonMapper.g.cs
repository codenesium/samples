using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesOrderHeaderSalesReasonMapper
	{
		public virtual DTOSalesOrderHeaderSalesReason MapModelToDTO(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model
			)
		{
			DTOSalesOrderHeaderSalesReason dtoSalesOrderHeaderSalesReason = new DTOSalesOrderHeaderSalesReason();

			dtoSalesOrderHeaderSalesReason.SetProperties(
				salesOrderID,
				model.ModifiedDate,
				model.SalesReasonID);
			return dtoSalesOrderHeaderSalesReason;
		}

		public virtual ApiSalesOrderHeaderSalesReasonResponseModel MapDTOToModel(
			DTOSalesOrderHeaderSalesReason dtoSalesOrderHeaderSalesReason)
		{
			if (dtoSalesOrderHeaderSalesReason == null)
			{
				return null;
			}

			var model = new ApiSalesOrderHeaderSalesReasonResponseModel();

			model.SetProperties(dtoSalesOrderHeaderSalesReason.ModifiedDate, dtoSalesOrderHeaderSalesReason.SalesOrderID, dtoSalesOrderHeaderSalesReason.SalesReasonID);

			return model;
		}

		public virtual List<ApiSalesOrderHeaderSalesReasonResponseModel> MapDTOToModel(
			List<DTOSalesOrderHeaderSalesReason> dtos)
		{
			List<ApiSalesOrderHeaderSalesReasonResponseModel> response = new List<ApiSalesOrderHeaderSalesReasonResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aa5030e4e4b43afa7e1783de5db6c5f5</Hash>
</Codenesium>*/