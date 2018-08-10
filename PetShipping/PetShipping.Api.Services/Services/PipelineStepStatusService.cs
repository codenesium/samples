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
	public partial class PipelineStepStatusService : AbstractPipelineStepStatusService, IPipelineStepStatusService
	{
		public PipelineStepStatusService(
			ILogger<IPipelineStepStatusRepository> logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
			IBOLPipelineStepStatusMapper bolpipelineStepStatusMapper,
			IDALPipelineStepStatusMapper dalpipelineStepStatusMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper
			)
			: base(logger,
			       pipelineStepStatusRepository,
			       pipelineStepStatusModelValidator,
			       bolpipelineStepStatusMapper,
			       dalpipelineStepStatusMapper,
			       bolPipelineStepMapper,
			       dalPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>694eb1e9174435f4da2c9eae32405790</Hash>
</Codenesium>*/