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
	public class PipelineStepRepository: AbstractPipelineStepRepository, IPipelineStepRepository
	{
		public PipelineStepRepository(
			IObjectMapper mapper,
			ILogger<PipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPipelineStep> SearchLinqEF(Expression<Func<EFPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStep>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStep>();
			}
			else
			{
				return this.Context.Set<EFPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStep>();
			}
		}

		protected override List<EFPipelineStep> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStep>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStep>();
			}
			else
			{
				return this.Context.Set<EFPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStep>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>eb759853ed34c622445834abc787b64b</Hash>
</Codenesium>*/