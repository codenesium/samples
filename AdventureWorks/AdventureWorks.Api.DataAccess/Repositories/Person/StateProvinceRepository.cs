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
		                               ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFStateProvince> SearchLinqEF(Expression<Func<EFStateProvince, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("stateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this._context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}

		protected override List<EFStateProvince> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("stateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this._context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>de65a2c4fc1f370c83ed0d1f9314bd1f</Hash>
</Codenesium>*/