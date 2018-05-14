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
			IApiPipelineStatusModelValidator pipelineStatusModelValidator)
			: base(logger, pipelineStatusRepository, pipelineStatusModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>bb230d0bc742132255aa6c256b4e6744</Hash>
</Codenesium>*/