using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStepStepRequirementRepository: AbstractPipelineStepStepRequirementRepository, IPipelineStepStepRequirementRepository
	{
		public PipelineStepStepRequirementRepository(
			IObjectMapper mapper,
			ILogger<PipelineStepStepRequirementRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPipelineStepStepRequirement> SearchLinqEF(Expression<Func<EFPipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepStepRequirement>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepStepRequirement>();
			}
		}

		protected override List<EFPipelineStepStepRequirement> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepStepRequirement>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepStepRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepStepRequirement>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>09806ce71fac717bd3cc55640ad88a54</Hash>
</Codenesium>*/