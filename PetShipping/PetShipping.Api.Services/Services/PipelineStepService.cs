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
	public class PipelineStepService: AbstractPipelineStepService, IPipelineStepService
	{
		public PipelineStepService(
			ILogger<PipelineStepRepository> logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
			IBOLPipelineStepMapper BOLpipelineStepMapper,
			IDALPipelineStepMapper DALpipelineStepMapper)
			: base(logger, pipelineStepRepository,
			       pipelineStepModelValidator,
			       BOLpipelineStepMapper,
			       DALpipelineStepMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7e5a8004c03944f2e847a6975f5fdef7</Hash>
</Codenesium>*/