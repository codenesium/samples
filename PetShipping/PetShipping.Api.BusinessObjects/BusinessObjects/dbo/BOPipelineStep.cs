using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOPipelineStep: AbstractBOPipelineStep, IBOPipelineStep
	{
		public BOPipelineStep(
			ILogger<PipelineStepRepository> logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
			IBOLPipelineStepMapper pipelineStepMapper)
			: base(logger, pipelineStepRepository, pipelineStepModelValidator, pipelineStepMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>73cf4a152ba56b75624cc08ef6b2a1e3</Hash>
</Codenesium>*/