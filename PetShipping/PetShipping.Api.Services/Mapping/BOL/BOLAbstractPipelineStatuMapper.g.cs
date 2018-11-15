using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStatuMapper
	{
		public virtual BOPipelineStatu MapModelToBO(
			int id,
			ApiPipelineStatuServerRequestModel model
			)
		{
			BOPipelineStatu boPipelineStatu = new BOPipelineStatu();
			boPipelineStatu.SetProperties(
				id,
				model.Name);
			return boPipelineStatu;
		}

		public virtual ApiPipelineStatuServerResponseModel MapBOToModel(
			BOPipelineStatu boPipelineStatu)
		{
			var model = new ApiPipelineStatuServerResponseModel();

			model.SetProperties(boPipelineStatu.Id, boPipelineStatu.Name);

			return model;
		}

		public virtual List<ApiPipelineStatuServerResponseModel> MapBOToModel(
			List<BOPipelineStatu> items)
		{
			List<ApiPipelineStatuServerResponseModel> response = new List<ApiPipelineStatuServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>073f88bb619e20321a7108bf6c081554</Hash>
</Codenesium>*/