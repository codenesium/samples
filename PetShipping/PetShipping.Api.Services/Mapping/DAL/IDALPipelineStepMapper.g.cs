using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepMapper
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
    <Hash>eaf7acbd01c6e438bfa494e53ab13759</Hash>
</Codenesium>*/