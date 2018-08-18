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
    <Hash>4bb43563d3068cd733971eaac4febb84</Hash>
</Codenesium>*/