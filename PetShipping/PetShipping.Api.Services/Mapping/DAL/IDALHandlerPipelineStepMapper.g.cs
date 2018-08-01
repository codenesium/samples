using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>17ccdea72a08c43a126cb83124436977</Hash>
</Codenesium>*/