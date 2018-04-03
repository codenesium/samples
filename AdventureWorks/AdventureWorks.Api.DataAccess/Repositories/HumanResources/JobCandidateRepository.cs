using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class JobCandidateRepository: AbstractJobCandidateRepository, IJobCandidateRepository
	{
		public JobCandidateRepository(ILogger<JobCandidateRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFJobCandidate> SearchLinqEF(Expression<Func<EFJobCandidate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("jobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this._context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}

		protected override List<EFJobCandidate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("jobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this._context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>559c9ff6af7a161b2f8dbe7b49482be3</Hash>
</Codenesium>*/