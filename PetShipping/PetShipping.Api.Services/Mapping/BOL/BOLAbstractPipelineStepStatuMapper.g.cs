using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepStatuMapper
	{
		public virtual BOPipelineStepStatu MapModelToBO(
			int id,
			ApiPipelineStepStatuServerRequestModel model
			)
		{
			BOPipelineStepStatu boPipelineStepStatu = new BOPipelineStepStatu();
			boPipelineStepStatu.SetProperties(
				id,
				model.Name);
			return boPipelineStepStatu;
		}

		public virtual ApiPipelineStepStatuServerResponseModel MapBOToModel(
			BOPipelineStepStatu boPipelineStepStatu)
		{
			var model = new ApiPipelineStepStatuServerResponseModel();

			model.SetProperties(boPipelineStepStatu.Id, boPipelineStepStatu.Name);

			return model;
		}

		public virtual List<ApiPipelineStepStatuServerResponseModel> MapBOToModel(
			List<BOPipelineStepStatu> items)
		{
			List<ApiPipelineStepStatuServerResponseModel> response = new List<ApiPipelineStepStatuServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>21717705cd8d220b23dc0229c4fb3540</Hash>
</Codenesium>*/