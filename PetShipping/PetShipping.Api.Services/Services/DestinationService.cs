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
	public partial class DestinationService : AbstractDestinationService, IDestinationService
	{
		public DestinationService(
			ILogger<IDestinationRepository> logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper boldestinationMapper,
			IDALDestinationMapper daldestinationMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper
			)
			: base(logger,
			       destinationRepository,
			       destinationModelValidator,
			       boldestinationMapper,
			       daldestinationMapper,
			       bolPipelineStepDestinationMapper,
			       dalPipelineStepDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b3c448e74ff95dc3f53172c7ae62fdeb</Hash>
</Codenesium>*/