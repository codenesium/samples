using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepStatusMapper
	{
		public virtual PipelineStepStatus MapModelToEntity(
			int id,
			ApiPipelineStepStatusServerRequestModel model
			)
		{
			PipelineStepStatus item = new PipelineStepStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPipelineStepStatusServerResponseModel MapEntityToModel(
			PipelineStepStatus item)
		{
			var model = new ApiPipelineStepStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPipelineStepStatusServerResponseModel> MapEntityToModel(
			List<PipelineStepStatus> items)
		{
			List<ApiPipelineStepStatusServerResponseModel> response = new List<ApiPipelineStepStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>689bdd7a1de0c63ce91e990a118385c1</Hash>
</Codenesium>*/