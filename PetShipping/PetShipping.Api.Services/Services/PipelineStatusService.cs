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
	public partial class PipelineStatusService : AbstractPipelineStatusService, IPipelineStatusService
	{
		public PipelineStatusService(
			ILogger<IPipelineStatusRepository> logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
			IBOLPipelineStatusMapper bolpipelineStatusMapper,
			IDALPipelineStatusMapper dalpipelineStatusMapper,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper
			)
			: base(logger,
			       pipelineStatusRepository,
			       pipelineStatusModelValidator,
			       bolpipelineStatusMapper,
			       dalpipelineStatusMapper,
			       bolPipelineMapper,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5c3b12b38e2bccd781a6df37ffbd092a</Hash>
</Codenesium>*/