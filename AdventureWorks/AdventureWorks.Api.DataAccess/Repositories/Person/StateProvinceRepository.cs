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
	public class StateProvinceRepository: AbstractStateProvinceRepository, IStateProvinceRepository
	{
		public StateProvinceRepository(ILogger<StateProvinceRepository> logger,
		                               ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFStateProvince> SearchLinqEF(Expression<Func<EFStateProvince, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("StateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}

		protected override List<EFStateProvince> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("StateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this.context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>4ce2c4addffa4af97cb6dea6ffd71719</Hash>
</Codenesium>*/