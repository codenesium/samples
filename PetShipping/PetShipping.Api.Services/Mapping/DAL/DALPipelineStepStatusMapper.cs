using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALPipelineStepStatusMapper : IDALPipelineStepStatusMapper
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
    <Hash>069fd59c1351d9f0692ca9677ae6a5f8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/