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
	public class SpecialOfferRepository: AbstractSpecialOfferRepository, ISpecialOfferRepository
	{
		public SpecialOfferRepository(ILogger<SpecialOfferRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSpecialOffer> SearchLinqEF(Expression<Func<EFSpecialOffer, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSpecialOffer>().Where(predicate).AsQueryable().OrderBy("SpecialOfferID ASC").Skip(skip).Take(take).ToList<EFSpecialOffer>();
			}
			else
			{
				return this._context.Set<EFSpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpecialOffer>();
			}
		}

		protected override List<EFSpecialOffer> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSpecialOffer>().Where(predicate).AsQueryable().OrderBy("SpecialOfferID ASC").Skip(skip).Take(take).ToList<EFSpecialOffer>();
			}
			else
			{
				return this._context.Set<EFSpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpecialOffer>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>daa59e399b7739a31688ee6629a73f2f</Hash>
</Codenesium>*/