using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineService : AbstractPipelineService, IPipelineService
	{
		public PipelineService(
			ILogger<IPipelineRepository> logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolpipelineMapper,
			IDALPipelineMapper dalpipelineMapper)
			: base(logger,
			       pipelineRepository,
			       pipelineModelValidator,
			       bolpipelineMapper,
			       dalpipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ad0c03fb20aceaab902284b516469141</Hash>
</Codenesium>*/