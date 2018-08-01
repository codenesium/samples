using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepStepRequirementService : AbstractPipelineStepStepRequirementService, IPipelineStepStepRequirementService
	{
		public PipelineStepStepRequirementService(
			ILogger<IPipelineStepStepRequirementRepository> logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper bolpipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalpipelineStepStepRequirementMapper
			)
			: base(logger,
			       pipelineStepStepRequirementRepository,
			       pipelineStepStepRequirementModelValidator,
			       bolpipelineStepStepRequirementMapper,
			       dalpipelineStepStepRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7355cb9950fae3f4e7df5a87c8bd783a</Hash>
</Codenesium>*/