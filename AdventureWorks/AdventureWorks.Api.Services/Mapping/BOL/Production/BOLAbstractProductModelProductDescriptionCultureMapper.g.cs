using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductModelProductDescriptionCultureMapper
	{
		public virtual BOProductModelProductDescriptionCulture MapModelToBO(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model
			)
		{
			BOProductModelProductDescriptionCulture BOProductModelProductDescriptionCulture = new BOProductModelProductDescriptionCulture();

			BOProductModelProductDescriptionCulture.SetProperties(
				productModelID,
				model.CultureID,
				model.ModifiedDate,
				model.ProductDescriptionID);
			return BOProductModelProductDescriptionCulture;
		}

		public virtual ApiProductModelProductDescriptionCultureResponseModel MapBOToModel(
			BOProductModelProductDescriptionCulture BOProductModelProductDescriptionCulture)
		{
			if (BOProductModelProductDescriptionCulture == null)
			{
				return null;
			}

			var model = new ApiProductModelProductDescriptionCultureResponseModel();

			model.SetProperties(BOProductModelProductDescriptionCulture.CultureID, BOProductModelProductDescriptionCulture.ModifiedDate, BOProductModelProductDescriptionCulture.ProductDescriptionID, BOProductModelProductDescriptionCulture.ProductModelID);

			return model;
		}

		public virtual List<ApiProductModelProductDescriptionCultureResponseModel> MapBOToModel(
			List<BOProductModelProductDescriptionCulture> BOs)
		{
			List<ApiProductModelProductDescriptionCultureResponseModel> response = new List<ApiProductModelProductDescriptionCultureResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3591666219a6c6aaddaad5735a3fa02a</Hash>
</Codenesium>*/