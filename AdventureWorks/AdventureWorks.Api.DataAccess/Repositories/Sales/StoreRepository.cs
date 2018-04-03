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
	public class StoreRepository: AbstractStoreRepository, IStoreRepository
	{
		public StoreRepository(ILogger<StoreRepository> logger,
		                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFStore> SearchLinqEF(Expression<Func<EFStore, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFStore>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFStore>();
			}
			else
			{
				return this._context.Set<EFStore>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStore>();
			}
		}

		protected override List<EFStore> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFStore>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFStore>();
			}
			else
			{
				return this._context.Set<EFStore>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStore>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a27147ff3602262d4896eb515e8cc692</Hash>
</Codenesium>*/