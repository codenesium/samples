using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductModelIllustrationMapper
	{
		public virtual BOProductModelIllustration MapModelToBO(
			int productModelID,
			ApiProductModelIllustrationRequestModel model
			)
		{
			BOProductModelIllustration boProductModelIllustration = new BOProductModelIllustration();
			boProductModelIllustration.SetProperties(
				productModelID,
				model.IllustrationID,
				model.ModifiedDate);
			return boProductModelIllustration;
		}

		public virtual ApiProductModelIllustrationResponseModel MapBOToModel(
			BOProductModelIllustration boProductModelIllustration)
		{
			var model = new ApiProductModelIllustrationResponseModel();

			model.SetProperties(boProductModelIllustration.ProductModelID, boProductModelIllustration.IllustrationID, boProductModelIllustration.ModifiedDate);

			return model;
		}

		public virtual List<ApiProductModelIllustrationResponseModel> MapBOToModel(
			List<BOProductModelIllustration> items)
		{
			List<ApiProductModelIllustrationResponseModel> response = new List<ApiProductModelIllustrationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>34ffa511d5f865bf426872ef5467b011</Hash>
</Codenesium>*/