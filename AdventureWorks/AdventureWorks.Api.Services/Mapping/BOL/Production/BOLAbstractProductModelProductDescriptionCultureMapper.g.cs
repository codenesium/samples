using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductModelProductDescriptionCultureMapper
	{
		public virtual BOProductModelProductDescriptionCulture MapModelToBO(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model
			)
		{
			BOProductModelProductDescriptionCulture boProductModelProductDescriptionCulture = new BOProductModelProductDescriptionCulture();
			boProductModelProductDescriptionCulture.SetProperties(
				productModelID,
				model.CultureID,
				model.ModifiedDate,
				model.ProductDescriptionID);
			return boProductModelProductDescriptionCulture;
		}

		public virtual ApiProductModelProductDescriptionCultureResponseModel MapBOToModel(
			BOProductModelProductDescriptionCulture boProductModelProductDescriptionCulture)
		{
			var model = new ApiProductModelProductDescriptionCultureResponseModel();

			model.SetProperties(boProductModelProductDescriptionCulture.ProductModelID, boProductModelProductDescriptionCulture.CultureID, boProductModelProductDescriptionCulture.ModifiedDate, boProductModelProductDescriptionCulture.ProductDescriptionID);

			return model;
		}

		public virtual List<ApiProductModelProductDescriptionCultureResponseModel> MapBOToModel(
			List<BOProductModelProductDescriptionCulture> items)
		{
			List<ApiProductModelProductDescriptionCultureResponseModel> response = new List<ApiProductModelProductDescriptionCultureResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>767b561eb2cd552c01c390886ac79901</Hash>
</Codenesium>*/