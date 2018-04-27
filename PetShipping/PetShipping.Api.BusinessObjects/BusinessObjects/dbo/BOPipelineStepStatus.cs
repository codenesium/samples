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
			IPipelineStepStatusModelValidator pipelineStepStatusModelValidator)
			: base(logger, pipelineStepStatusRepository, pipelineStepStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e7395ac990ca0388301ce072d578d93d</Hash>
</Codenesium>*/