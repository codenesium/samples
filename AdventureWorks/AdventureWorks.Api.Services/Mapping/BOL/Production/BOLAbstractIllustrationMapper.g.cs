using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractIllustrationMapper
	{
		public virtual BOIllustration MapModelToBO(
			int illustrationID,
			ApiIllustrationServerRequestModel model
			)
		{
			BOIllustration boIllustration = new BOIllustration();
			boIllustration.SetProperties(
				illustrationID,
				model.Diagram,
				model.ModifiedDate);
			return boIllustration;
		}

		public virtual ApiIllustrationServerResponseModel MapBOToModel(
			BOIllustration boIllustration)
		{
			var model = new ApiIllustrationServerResponseModel();

			model.SetProperties(boIllustration.IllustrationID, boIllustration.Diagram, boIllustration.ModifiedDate);

			return model;
		}

		public virtual List<ApiIllustrationServerResponseModel> MapBOToModel(
			List<BOIllustration> items)
		{
			List<ApiIllustrationServerResponseModel> response = new List<ApiIllustrationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c34edac507ef5bc9f943e153f9c504ab</Hash>
</Codenesium>*/