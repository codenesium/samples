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
			IApiPipelineStepStatusModelValidator pipelineStepStatusModelValidator)
			: base(logger, pipelineStepStatusRepository, pipelineStepStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>580e8fbd8d1d94fc9ee07fbe8154396c</Hash>
</Codenesium>*/