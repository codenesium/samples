using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepStepRequirementService : AbstractPipelineStepStepRequirementService, IPipelineStepStepRequirementService
	{
		public PipelineStepStepRequirementService(
			ILogger<IPipelineStepStepRequirementRepository> logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper bolpipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalpipelineStepStepRequirementMapper)
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
    <Hash>07a4e33d6ba68777b8c57c5718eab1f7</Hash>
</Codenesium>*/