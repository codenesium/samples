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
	public class HandlerPipelineStepRepository: AbstractHandlerPipelineStepRepository, IHandlerPipelineStepRepository
	{
		public HandlerPipelineStepRepository(
			IObjectMapper mapper,
			ILogger<HandlerPipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFHandlerPipelineStep> SearchLinqEF(Expression<Func<EFHandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFHandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFHandlerPipelineStep>();
			}
			else
			{
				return this.Context.Set<EFHandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFHandlerPipelineStep>();
			}
		}

		protected override List<EFHandlerPipelineStep> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFHandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFHandlerPipelineStep>();
			}
			else
			{
				return this.Context.Set<EFHandlerPipelineStep>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFHandlerPipelineStep>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7b96801dfdf8480384bcd60e0a3634bc</Hash>
</Codenesium>*/