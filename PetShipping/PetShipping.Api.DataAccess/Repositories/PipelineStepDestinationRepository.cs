using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStepDestinationRepository : AbstractPipelineStepDestinationRepository, IPipelineStepDestinationRepository
	{
		public PipelineStepDestinationRepository(
			ILogger<PipelineStepDestinationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c19bd154452997cefcb17785ee453901</Hash>
</Codenesium>*/