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
			IPipelineStatusModelValidator pipelineStatusModelValidator)
			: base(logger, pipelineStatusRepository, pipelineStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>fd067443b3cb3a683ab21dda54f2f860</Hash>
</Codenesium>*/