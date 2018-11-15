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
    <Hash>dbb208cc5dffb174089e29074a849074</Hash>
</Codenesium>*/