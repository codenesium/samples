using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLVendorMapper
	{
		public virtual DTOVendor MapModelToDTO(
			int businessEntityID,
			ApiVendorRequestModel model
			)
		{
			DTOVendor dtoVendor = new DTOVendor();

			dtoVendor.SetProperties(
				businessEntityID,
				model.AccountNumber,
				model.ActiveFlag,
				model.CreditRating,
				model.ModifiedDate,
				model.Name,
				model.PreferredVendorStatus,
				model.PurchasingWebServiceURL);
			return dtoVendor;
		}

		public virtual ApiVendorResponseModel MapDTOToModel(
			DTOVendor dtoVendor)
		{
			if (dtoVendor == null)
			{
				return null;
			}

			var model = new ApiVendorResponseModel();

			model.SetProperties(dtoVendor.AccountNumber, dtoVendor.ActiveFlag, dtoVendor.BusinessEntityID, dtoVendor.CreditRating, dtoVendor.ModifiedDate, dtoVendor.Name, dtoVendor.PreferredVendorStatus, dtoVendor.PurchasingWebServiceURL);

			return model;
		}

		public virtual List<ApiVendorResponseModel> MapDTOToModel(
			List<DTOVendor> dtos)
		{
			List<ApiVendorResponseModel> response = new List<ApiVendorResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>526411ee4d7ed221d5c03c0dc4d587bd</Hash>
</Codenesium>*/