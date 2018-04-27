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
	public class PipelineStepStatusRepository: AbstractPipelineStepStatusRepository, IPipelineStepStatusRepository
	{
		public PipelineStepStatusRepository(
			IObjectMapper mapper,
			ILogger<PipelineStepStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPipelineStepStatus> SearchLinqEF(Expression<Func<EFPipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepStatus>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepStatus>();
			}
		}

		protected override List<EFPipelineStepStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepStatus>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>5ccf90d4858f84c2aaa39f6f1345c057</Hash>
</Codenesium>*/