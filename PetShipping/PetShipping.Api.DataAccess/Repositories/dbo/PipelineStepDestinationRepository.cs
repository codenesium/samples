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
	public class PipelineStepDestinationRepository: AbstractPipelineStepDestinationRepository, IPipelineStepDestinationRepository
	{
		public PipelineStepDestinationRepository(
			IObjectMapper mapper,
			ILogger<PipelineStepDestinationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPipelineStepDestination> SearchLinqEF(Expression<Func<EFPipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepDestination>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepDestination>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepDestination>();
			}
		}

		protected override List<EFPipelineStepDestination> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepDestination>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepDestination>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepDestination>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepDestination>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a234b4c3009f99cea123252979aa2ac2</Hash>
</Codenesium>*/