using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALPipelineStepDestinationMapper
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
    <Hash>a79ea7a31605ff4fb0ca5f62619ebb39</Hash>
</Codenesium>*/