using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStatuMapper
	{
		public virtual BOPipelineStatu MapModelToBO(
			int id,
			ApiPipelineStatuRequestModel model
			)
		{
			BOPipelineStatu boPipelineStatu = new BOPipelineStatu();
			boPipelineStatu.SetProperties(
				id,
				model.Name);
			return boPipelineStatu;
		}

		public virtual ApiPipelineStatuResponseModel MapBOToModel(
			BOPipelineStatu boPipelineStatu)
		{
			var model = new ApiPipelineStatuResponseModel();

			model.SetProperties(boPipelineStatu.Id, boPipelineStatu.Name);

			return model;
		}

		public virtual List<ApiPipelineStatuResponseModel> MapBOToModel(
			List<BOPipelineStatu> items)
		{
			List<ApiPipelineStatuResponseModel> response = new List<ApiPipelineStatuResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a541d5f456431db8775cf31d48138d7d</Hash>
</Codenesium>*/