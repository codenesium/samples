using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractIllustrationMapper
	{
		public virtual BOIllustration MapModelToBO(
			int illustrationID,
			ApiIllustrationRequestModel model
			)
		{
			BOIllustration BOIllustration = new BOIllustration();

			BOIllustration.SetProperties(
				illustrationID,
				model.Diagram,
				model.ModifiedDate);
			return BOIllustration;
		}

		public virtual ApiIllustrationResponseModel MapBOToModel(
			BOIllustration BOIllustration)
		{
			if (BOIllustration == null)
			{
				return null;
			}

			var model = new ApiIllustrationResponseModel();

			model.SetProperties(BOIllustration.Diagram, BOIllustration.IllustrationID, BOIllustration.ModifiedDate);

			return model;
		}

		public virtual List<ApiIllustrationResponseModel> MapBOToModel(
			List<BOIllustration> BOs)
		{
			List<ApiIllustrationResponseModel> response = new List<ApiIllustrationResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>405bebf09855938190ce5496abba262b</Hash>
</Codenesium>*/