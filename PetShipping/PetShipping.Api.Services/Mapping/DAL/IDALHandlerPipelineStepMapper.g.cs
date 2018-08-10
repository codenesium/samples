using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALHandlerPipelineStepMapper
	{
		HandlerPipelineStep MapBOToEF(
			BOHandlerPipelineStep bo);

		BOHandlerPipelineStep MapEFToBO(
			HandlerPipelineStep efHandlerPipelineStep);

		List<BOHandlerPipelineStep> MapEFToBO(
			List<HandlerPipelineStep> records);
	}
}

/*<Codenesium>
    <Hash>81d75b60f85a5c1f927ab7a060d4e178</Hash>
</Codenesium>*/