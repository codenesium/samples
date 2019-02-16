using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStatuMapper
	{
		public virtual PipelineStatu MapModelToEntity(
			int id,
			ApiPipelineStatuServerRequestModel model
			)
		{
			PipelineStatu item = new PipelineStatu();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPipelineStatuServerResponseModel MapEntityToModel(
			PipelineStatu item)
		{
			var model = new ApiPipelineStatuServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPipelineStatuServerResponseModel> MapEntityToModel(
			List<PipelineStatu> items)
		{
			List<ApiPipelineStatuServerResponseModel> response = new List<ApiPipelineStatuServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d55d784ba1bf6d8c776cd6a988d2f0b3</Hash>
</Codenesium>*/