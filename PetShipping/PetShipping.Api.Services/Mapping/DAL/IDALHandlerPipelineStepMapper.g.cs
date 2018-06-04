using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALHandlerPipelineStepMapper
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
    <Hash>1e0f2eb7bd5e23f38e5d0f2cada7f72f</Hash>
</Codenesium>*/