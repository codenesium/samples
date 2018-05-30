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
	public class BOPipelineStepStatus: AbstractBOPipelineStepStatus, IBOPipelineStepStatus
	{
		public BOPipelineStepStatus(
			ILogger<PipelineStepStatusRepository> logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
			IBOLPipelineStepStatusMapper pipelineStepStatusMapper)
			: base(logger, pipelineStepStatusRepository, pipelineStepStatusModelValidator, pipelineStepStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ff222140627f43b3c42f7bf917ce887a</Hash>
</Codenesium>*/