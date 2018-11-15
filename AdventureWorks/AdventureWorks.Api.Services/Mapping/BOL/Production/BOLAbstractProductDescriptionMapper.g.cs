using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductDescriptionMapper
	{
		public virtual BOProductDescription MapModelToBO(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel model
			)
		{
			BOProductDescription boProductDescription = new BOProductDescription();
			boProductDescription.SetProperties(
				productDescriptionID,
				model.Description,
				model.ModifiedDate,
				model.Rowguid);
			return boProductDescription;
		}

		public virtual ApiProductDescriptionServerResponseModel MapBOToModel(
			BOProductDescription boProductDescription)
		{
			var model = new ApiProductDescriptionServerResponseModel();

			model.SetProperties(boProductDescription.ProductDescriptionID, boProductDescription.Description, boProductDescription.ModifiedDate, boProductDescription.Rowguid);

			return model;
		}

		public virtual List<ApiProductDescriptionServerResponseModel> MapBOToModel(
			List<BOProductDescription> items)
		{
			List<ApiProductDescriptionServerResponseModel> response = new List<ApiProductDescriptionServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>92d2170c37a70bb681d7855cecf25a00</Hash>
</Codenesium>*/