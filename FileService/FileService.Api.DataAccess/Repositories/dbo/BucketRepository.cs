using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class BucketRepository: AbstractBucketRepository
	{
		public BucketRepository(ILogger logger,
		                        DbContext context) : base(logger,context)
		{}

		protected override List<Bucket> SearchLinqEF(Expression<Func<Bucket, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Bucket>();
			}
			else
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Bucket>();
			}
		}

		protected override List<Bucket> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Bucket>();
			}
			else
			{
				return this._context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Bucket>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>0b18a4af4dcec2fd1e8c19482fb566ae</Hash>
</Codenesium>*/