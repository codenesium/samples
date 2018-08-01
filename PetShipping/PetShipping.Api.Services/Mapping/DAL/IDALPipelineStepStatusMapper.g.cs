using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c86b647134d27cde58e39ff809da07c2</Hash>
</Codenesium>*/