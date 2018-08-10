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
    <Hash>0ed9819e305ad21825a1888350dbbdc5</Hash>
</Codenesium>*/