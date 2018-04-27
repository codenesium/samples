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
	public class PipelineStepNoteRepository: AbstractPipelineStepNoteRepository, IPipelineStepNoteRepository
	{
		public PipelineStepNoteRepository(
			IObjectMapper mapper,
			ILogger<PipelineStepNoteRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPipelineStepNote> SearchLinqEF(Expression<Func<EFPipelineStepNote, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepNote>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepNote>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepNote>();
			}
		}

		protected override List<EFPipelineStepNote> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPipelineStepNote>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPipelineStepNote>();
			}
			else
			{
				return this.Context.Set<EFPipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPipelineStepNote>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>05e4d262f170619cdd58f98209f056d6</Hash>
</Codenesium>*/