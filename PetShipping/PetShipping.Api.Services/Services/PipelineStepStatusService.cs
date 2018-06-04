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
	public class PipelineStepStatusService: AbstractPipelineStepStatusService, IPipelineStepStatusService
	{
		public PipelineStepStatusService(
			ILogger<PipelineStepStatusRepository> logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
			IBOLPipelineStepStatusMapper BOLpipelineStepStatusMapper,
			IDALPipelineStepStatusMapper DALpipelineStepStatusMapper)
			: base(logger, pipelineStepStatusRepository,
			       pipelineStepStatusModelValidator,
			       BOLpipelineStepStatusMapper,
			       DALpipelineStepStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8e4e89fabbd239a8eb0cab4dc40143de</Hash>
</Codenesium>*/