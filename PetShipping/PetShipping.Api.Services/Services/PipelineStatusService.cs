using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>0702d5043bbb4e541533143b4169fe1d</Hash>
</Codenesium>*/