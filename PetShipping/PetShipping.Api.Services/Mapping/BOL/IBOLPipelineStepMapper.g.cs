using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineStepMapper
	{
		BOPipelineStep MapModelToBO(
			int id,
			ApiPipelineStepRequestModel model);

		ApiPipelineStepResponseModel MapBOToModel(
			BOPipelineStep boPipelineStep);

		List<ApiPipelineStepResponseModel> MapBOToModel(
			List<BOPipelineStep> bos);
	}
}

/*<Codenesium>
    <Hash>741022647d8becfbc493ae139c04783f</Hash>
</Codenesium>*/