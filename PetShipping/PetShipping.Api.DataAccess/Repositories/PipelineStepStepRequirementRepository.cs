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
	public partial class PipelineStepStepRequirementRepository : AbstractPipelineStepStepRequirementRepository, IPipelineStepStepRequirementRepository
	{
		public PipelineStepStepRequirementRepository(
			ILogger<PipelineStepStepRequirementRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>80eb42d95020762c37f68d13fef04e59</Hash>
</Codenesium>*/