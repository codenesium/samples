using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepStatusMapper
	{
		public virtual BOPipelineStepStatus MapModelToBO(
			int id,
			ApiPipelineStepStatusRequestModel model
			)
		{
			BOPipelineStepStatus boPipelineStepStatus = new BOPipelineStepStatus();
			boPipelineStepStatus.SetProperties(
				id,
				model.Name);
			return boPipelineStepStatus;
		}

		public virtual ApiPipelineStepStatusResponseModel MapBOToModel(
			BOPipelineStepStatus boPipelineStepStatus)
		{
			var model = new ApiPipelineStepStatusResponseModel();

			model.SetProperties(boPipelineStepStatus.Id, boPipelineStepStatus.Name);

			return model;
		}

		public virtual List<ApiPipelineStepStatusResponseModel> MapBOToModel(
			List<BOPipelineStepStatus> items)
		{
			List<ApiPipelineStepStatusResponseModel> response = new List<ApiPipelineStepStatusResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9926ccb3e077ae4c86bbab022f2b2fbb</Hash>
</Codenesium>*/