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
	public class SpecialOfferProductRepository: AbstractSpecialOfferProductRepository, ISpecialOfferProductRepository
	{
		public SpecialOfferProductRepository(ILogger<SpecialOfferProductRepository> logger,
		                                     ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFSpecialOfferProduct> SearchLinqEF(Expression<Func<EFSpecialOfferProduct, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy("SpecialOfferID ASC").Skip(skip).Take(take).ToList<EFSpecialOfferProduct>();
			}
			else
			{
				return this.context.Set<EFSpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpecialOfferProduct>();
			}
		}

		protected override List<EFSpecialOfferProduct> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy("SpecialOfferID ASC").Skip(skip).Take(take).ToList<EFSpecialOfferProduct>();
			}
			else
			{
				return this.context.Set<EFSpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSpecialOfferProduct>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>bf82c435abe10c713309fa116e76721e</Hash>
</Codenesium>*/