using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductModelIllustrationMapper
	{
		public virtual BOProductModelIllustration MapModelToBO(
			int productModelID,
			ApiProductModelIllustrationRequestModel model
			)
		{
			BOProductModelIllustration BOProductModelIllustration = new BOProductModelIllustration();

			BOProductModelIllustration.SetProperties(
				productModelID,
				model.IllustrationID,
				model.ModifiedDate);
			return BOProductModelIllustration;
		}

		public virtual ApiProductModelIllustrationResponseModel MapBOToModel(
			BOProductModelIllustration BOProductModelIllustration)
		{
			if (BOProductModelIllustration == null)
			{
				return null;
			}

			var model = new ApiProductModelIllustrationResponseModel();

			model.SetProperties(BOProductModelIllustration.IllustrationID, BOProductModelIllustration.ModifiedDate, BOProductModelIllustration.ProductModelID);

			return model;
		}

		public virtual List<ApiProductModelIllustrationResponseModel> MapBOToModel(
			List<BOProductModelIllustration> BOs)
		{
			List<ApiProductModelIllustrationResponseModel> response = new List<ApiProductModelIllustrationResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>00439bed231753d94f2734faeb17839a</Hash>
</Codenesium>*/