using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepStatuMapper
	{
		public virtual BOPipelineStepStatu MapModelToBO(
			int id,
			ApiPipelineStepStatuRequestModel model
			)
		{
			BOPipelineStepStatu boPipelineStepStatu = new BOPipelineStepStatu();
			boPipelineStepStatu.SetProperties(
				id,
				model.Name);
			return boPipelineStepStatu;
		}

		public virtual ApiPipelineStepStatuResponseModel MapBOToModel(
			BOPipelineStepStatu boPipelineStepStatu)
		{
			var model = new ApiPipelineStepStatuResponseModel();

			model.SetProperties(boPipelineStepStatu.Id, boPipelineStepStatu.Name);

			return model;
		}

		public virtual List<ApiPipelineStepStatuResponseModel> MapBOToModel(
			List<BOPipelineStepStatu> items)
		{
			List<ApiPipelineStepStatuResponseModel> response = new List<ApiPipelineStepStatuResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>de252a14dfecc87f0f70b4e7f071c507</Hash>
</Codenesium>*/