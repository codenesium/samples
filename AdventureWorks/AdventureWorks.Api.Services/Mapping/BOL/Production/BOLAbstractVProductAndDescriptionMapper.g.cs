using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractVProductAndDescriptionMapper
	{
		public virtual BOVProductAndDescription MapModelToBO(
			string cultureID,
			ApiVProductAndDescriptionRequestModel model
			)
		{
			BOVProductAndDescription boVProductAndDescription = new BOVProductAndDescription();
			boVProductAndDescription.SetProperties(
				cultureID,
				model.Description,
				model.Name,
				model.ProductID,
				model.ProductModel);
			return boVProductAndDescription;
		}

		public virtual ApiVProductAndDescriptionResponseModel MapBOToModel(
			BOVProductAndDescription boVProductAndDescription)
		{
			var model = new ApiVProductAndDescriptionResponseModel();

			model.SetProperties(boVProductAndDescription.CultureID, boVProductAndDescription.Description, boVProductAndDescription.Name, boVProductAndDescription.ProductID, boVProductAndDescription.ProductModel);

			return model;
		}

		public virtual List<ApiVProductAndDescriptionResponseModel> MapBOToModel(
			List<BOVProductAndDescription> items)
		{
			List<ApiVProductAndDescriptionResponseModel> response = new List<ApiVProductAndDescriptionResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c8a545abb078dc0c784329ec84d4dff2</Hash>
</Codenesium>*/