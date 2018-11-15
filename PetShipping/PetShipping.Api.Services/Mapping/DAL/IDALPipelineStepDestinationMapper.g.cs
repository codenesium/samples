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
    <Hash>c7ba6fc9fe901860e59b47fe6db52211</Hash>
</Codenesium>*/