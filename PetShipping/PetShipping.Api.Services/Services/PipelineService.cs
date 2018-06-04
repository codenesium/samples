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
	public class PipelineService: AbstractPipelineService, IPipelineService
	{
		public PipelineService(
			ILogger<PipelineRepository> logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper BOLpipelineMapper,
			IDALPipelineMapper DALpipelineMapper)
			: base(logger, pipelineRepository,
			       pipelineModelValidator,
			       BOLpipelineMapper,
			       DALpipelineMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6295b9a9ed45940d1f675971988caec4</Hash>
</Codenesium>*/