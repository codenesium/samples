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
	public class PipelineStatusService: AbstractPipelineStatusService, IPipelineStatusService
	{
		public PipelineStatusService(
			ILogger<PipelineStatusRepository> logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
			IBOLPipelineStatusMapper BOLpipelineStatusMapper,
			IDALPipelineStatusMapper DALpipelineStatusMapper)
			: base(logger, pipelineStatusRepository,
			       pipelineStatusModelValidator,
			       BOLpipelineStatusMapper,
			       DALpipelineStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>67c1b4f7b02fcaa2b27eb2a1bb50b162</Hash>
</Codenesium>*/