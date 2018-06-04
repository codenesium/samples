using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>2ba01a63a5e7afa92f2000025960f5cf</Hash>
</Codenesium>*/