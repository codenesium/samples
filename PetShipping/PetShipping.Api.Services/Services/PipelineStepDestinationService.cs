using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepDestinationService: AbstractPipelineStepDestinationService, IPipelineStepDestinationService
	{
		public PipelineStepDestinationService(
			ILogger<PipelineStepDestinationRepository> logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator,
			IBOLPipelineStepDestinationMapper BOLpipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper DALpipelineStepDestinationMapper)
			: base(logger, pipelineStepDestinationRepository,
			       pipelineStepDestinationModelValidator,
			       BOLpipelineStepDestinationMapper,
			       DALpipelineStepDestinationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>754c46e6ef2b689c01c255616a9b67a8</Hash>
</Codenesium>*/