using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class BucketRepository: AbstractBucketRepository, IBucketRepository
	{
		public BucketRepository(ILogger<BucketRepository> logger,
		                        ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFBucket> SearchLinqEF(Expression<Func<EFBucket, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBucket>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFBucket>();
			}
			else
			{
				return this._context.Set<EFBucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBucket>();
			}
		}

		protected override List<EFBucket> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBucket>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFBucket>();
			}
			else
			{
				return this._context.Set<EFBucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBucket>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2cc5cc6c33a9995cd39871ba55374529</Hash>
</Codenesium>*/