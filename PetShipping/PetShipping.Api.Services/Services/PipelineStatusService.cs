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
    <Hash>d15878866d01e32f2a9da67af91bbe88</Hash>
</Codenesium>*/