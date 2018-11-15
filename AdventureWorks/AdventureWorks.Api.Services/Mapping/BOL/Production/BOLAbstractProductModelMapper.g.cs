using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductModelMapper
	{
		public virtual BOProductModel MapModelToBO(
			int productModelID,
			ApiProductModelServerRequestModel model
			)
		{
			BOProductModel boProductModel = new BOProductModel();
			boProductModel.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instruction,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return boProductModel;
		}

		public virtual ApiProductModelServerResponseModel MapBOToModel(
			BOProductModel boProductModel)
		{
			var model = new ApiProductModelServerResponseModel();

			model.SetProperties(boProductModel.ProductModelID, boProductModel.CatalogDescription, boProductModel.Instruction, boProductModel.ModifiedDate, boProductModel.Name, boProductModel.Rowguid);

			return model;
		}

		public virtual List<ApiProductModelServerResponseModel> MapBOToModel(
			List<BOProductModel> items)
		{
			List<ApiProductModelServerResponseModel> response = new List<ApiProductModelServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bd2c5e376a97d2406f449875b1d9e75f</Hash>
</Codenesium>*/