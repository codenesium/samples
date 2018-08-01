using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductDescriptionMapper
	{
		public virtual BOProductDescription MapModelToBO(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model
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

		public virtual ApiProductDescriptionResponseModel MapBOToModel(
			BOProductDescription boProductDescription)
		{
			var model = new ApiProductDescriptionResponseModel();

			model.SetProperties(boProductDescription.ProductDescriptionID, boProductDescription.Description, boProductDescription.ModifiedDate, boProductDescription.Rowguid);

			return model;
		}

		public virtual List<ApiProductDescriptionResponseModel> MapBOToModel(
			List<BOProductDescription> items)
		{
			List<ApiProductDescriptionResponseModel> response = new List<ApiProductDescriptionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5397d2d299bf92616c90f09ab6d15bf5</Hash>
</Codenesium>*/