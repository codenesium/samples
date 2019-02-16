using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepStatuMapper
	{
		public virtual PipelineStepStatu MapModelToEntity(
			int id,
			ApiPipelineStepStatuServerRequestModel model
			)
		{
			PipelineStepStatu item = new PipelineStepStatu();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPipelineStepStatuServerResponseModel MapEntityToModel(
			PipelineStepStatu item)
		{
			var model = new ApiPipelineStepStatuServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPipelineStepStatuServerResponseModel> MapEntityToModel(
			List<PipelineStepStatu> items)
		{
			List<ApiPipelineStepStatuServerResponseModel> response = new List<ApiPipelineStepStatuServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>95b53ac406a150547c87bf1eef50f518</Hash>
</Codenesium>*/