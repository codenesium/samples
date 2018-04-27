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
	public class PipelineRepository: AbstractPipelineRepository, IPipelineRepository
	{
		public PipelineRepository(
			IObjectMapper mapper,
			ILogger<PipelineRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPipeline> SearchLinqEF(Expression<Func<EFPipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipeline>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipeline>();
			}
			else
			{
				return this.Context.Set<EFPipeline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipeline>();
			}
		}

		protected override List<EFPipeline> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipeline>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipeline>();
			}
			else
			{
				return this.Context.Set<EFPipeline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipeline>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7272afe2cda41695308bf934b0fb533c</Hash>
</Codenesium>*/