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
    <Hash>11c68dd6222bf80ef02ada7a0f820f09</Hash>
</Codenesium>*/