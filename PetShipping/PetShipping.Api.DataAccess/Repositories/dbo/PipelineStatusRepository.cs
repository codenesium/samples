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
	public class PipelineStatusRepository: AbstractPipelineStatusRepository, IPipelineStatusRepository
	{
		public PipelineStatusRepository(
			IObjectMapper mapper,
			ILogger<PipelineStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPipelineStatus> SearchLinqEF(Expression<Func<EFPipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStatus>();
			}
			else
			{
				return this.Context.Set<EFPipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStatus>();
			}
		}

		protected override List<EFPipelineStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStatus>();
			}
			else
			{
				return this.Context.Set<EFPipelineStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>27bdefa2c2cdf335887b9f4093d27459</Hash>
</Codenesium>*/