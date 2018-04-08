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
		                              ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFJobCandidate> SearchLinqEF(Expression<Func<EFJobCandidate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("JobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this.context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}

		protected override List<EFJobCandidate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("JobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this.context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f21773964de7f8e098aea4ed1a741900</Hash>
</Codenesium>*/