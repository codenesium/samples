using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALPipelineStepMapper
	{
		PipelineStep MapBOToEF(
			BOPipelineStep bo);

		BOPipelineStep MapEFToBO(
			PipelineStep efPipelineStep);

		List<BOPipelineStep> MapEFToBO(
			List<PipelineStep> records);
	}
}

/*<Codenesium>
    <Hash>a6641344ad63a70546e5670ceae6e46c</Hash>
</Codenesium>*/