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
	public class BOPipelineStatus: AbstractBOPipelineStatus, IBOPipelineStatus
	{
		public BOPipelineStatus(
			ILogger<PipelineStatusRepository> logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
			IBOLPipelineStatusMapper pipelineStatusMapper)
			: base(logger, pipelineStatusRepository, pipelineStatusModelValidator, pipelineStatusMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8c1a245dfa6afcd7b8d4c2628c056b64</Hash>
</Codenesium>*/