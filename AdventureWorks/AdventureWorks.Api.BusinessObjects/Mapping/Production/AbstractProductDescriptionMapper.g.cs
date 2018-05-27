using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductDescriptionMapper
	{
		public virtual DTOProductDescription MapModelToDTO(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model
			)
		{
			DTOProductDescription dtoProductDescription = new DTOProductDescription();

			dtoProductDescription.SetProperties(
				productDescriptionID,
				model.Description,
				model.ModifiedDate,
				model.Rowguid);
			return dtoProductDescription;
		}

		public virtual ApiProductDescriptionResponseModel MapDTOToModel(
			DTOProductDescription dtoProductDescription)
		{
			if (dtoProductDescription == null)
			{
				return null;
			}

			var model = new ApiProductDescriptionResponseModel();

			model.SetProperties(dtoProductDescription.Description, dtoProductDescription.ModifiedDate, dtoProductDescription.ProductDescriptionID, dtoProductDescription.Rowguid);

			return model;
		}

		public virtual List<ApiProductDescriptionResponseModel> MapDTOToModel(
			List<DTOProductDescription> dtos)
		{
			List<ApiProductDescriptionResponseModel> response = new List<ApiProductDescriptionResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f6b100beb8d90b4f92cb542e3203a9cc</Hash>
</Codenesium>*/