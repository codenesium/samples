using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepDestinationMapper
	{
		PipelineStepDestination MapBOToEF(
			BOPipelineStepDestination bo);

		BOPipelineStepDestination MapEFToBO(
			PipelineStepDestination efPipelineStepDestination);

		List<BOPipelineStepDestination> MapEFToBO(
			List<PipelineStepDestination> records);
	}
}

/*<Codenesium>
    <Hash>c3ddde03f872afd246ba78bafb9f614b</Hash>
</Codenesium>*/