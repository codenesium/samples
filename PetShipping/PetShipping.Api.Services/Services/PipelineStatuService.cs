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
	public partial class PipelineStatuService : AbstractPipelineStatuService, IPipelineStatuService
	{
		public PipelineStatuService(
			ILogger<IPipelineStatuRepository> logger,
			IPipelineStatuRepository pipelineStatuRepository,
			IApiPipelineStatuRequestModelValidator pipelineStatuModelValidator,
			IBOLPipelineStatuMapper bolpipelineStatuMapper,
			IDALPipelineStatuMapper dalpipelineStatuMapper,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
			       pipelineStatuRepository,
			       pipelineStatuModelValidator,
			       bolpipelineStatuMapper,
			       dalpipelineStatuMapper,
			       bolPipelineMapper,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ae712d38b7138034a3b974483ebdb09e</Hash>
</Codenesium>*/