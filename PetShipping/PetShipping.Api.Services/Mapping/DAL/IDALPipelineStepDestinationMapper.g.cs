using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>1e2ccc0eec5ad8558dda5b4944f4d99c</Hash>
</Codenesium>*/