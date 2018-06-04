using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALPipelineStepStatusMapper
	{
		PipelineStepStatus MapBOToEF(
			BOPipelineStepStatus bo);

		BOPipelineStepStatus MapEFToBO(
			PipelineStepStatus efPipelineStepStatus);

		List<BOPipelineStepStatus> MapEFToBO(
			List<PipelineStepStatus> records);
	}
}

/*<Codenesium>
    <Hash>d41601126cffb79eb30fd9aafe1e7222</Hash>
</Codenesium>*/