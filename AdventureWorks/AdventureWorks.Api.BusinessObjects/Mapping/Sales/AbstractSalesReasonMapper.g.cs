using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesReasonMapper
	{
		public virtual DTOSalesReason MapModelToDTO(
			int salesReasonID,
			ApiSalesReasonRequestModel model
			)
		{
			DTOSalesReason dtoSalesReason = new DTOSalesReason();

			dtoSalesReason.SetProperties(
				salesReasonID,
				model.ModifiedDate,
				model.Name,
				model.ReasonType);
			return dtoSalesReason;
		}

		public virtual ApiSalesReasonResponseModel MapDTOToModel(
			DTOSalesReason dtoSalesReason)
		{
			if (dtoSalesReason == null)
			{
				return null;
			}

			var model = new ApiSalesReasonResponseModel();

			model.SetProperties(dtoSalesReason.ModifiedDate, dtoSalesReason.Name, dtoSalesReason.ReasonType, dtoSalesReason.SalesReasonID);

			return model;
		}

		public virtual List<ApiSalesReasonResponseModel> MapDTOToModel(
			List<DTOSalesReason> dtos)
		{
			List<ApiSalesReasonResponseModel> response = new List<ApiSalesReasonResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>359838a4e1f84bcc16f9f89994719f4f</Hash>
</Codenesium>*/