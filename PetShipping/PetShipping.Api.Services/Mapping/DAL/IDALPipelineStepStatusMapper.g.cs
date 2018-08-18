using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepStatusMapper
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
    <Hash>4a46e528991be0dc0fe1439f28004187</Hash>
</Codenesium>*/