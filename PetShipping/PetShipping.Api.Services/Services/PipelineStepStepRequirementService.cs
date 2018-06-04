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
	public class PipelineStepStepRequirementService: AbstractPipelineStepStepRequirementService, IPipelineStepStepRequirementService
	{
		public PipelineStepStepRequirementService(
			ILogger<PipelineStepStepRequirementRepository> logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper BOLpipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper DALpipelineStepStepRequirementMapper)
			: base(logger, pipelineStepStepRequirementRepository,
			       pipelineStepStepRequirementModelValidator,
			       BOLpipelineStepStepRequirementMapper,
			       DALpipelineStepStepRequirementMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>335cd91bfc6d13a0603748a42a4722d6</Hash>
</Codenesium>*/