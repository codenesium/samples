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
	public class VendorRepository: AbstractVendorRepository, IVendorRepository
	{
		public VendorRepository(ILogger<VendorRepository> logger,
		                        ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFVendor> SearchLinqEF(Expression<Func<EFVendor, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFVendor>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFVendor>();
			}
			else
			{
				return this._context.Set<EFVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFVendor>();
			}
		}

		protected override List<EFVendor> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFVendor>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFVendor>();
			}
			else
			{
				return this._context.Set<EFVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFVendor>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e279982fdaa9a1be55dc45f3630a0e1d</Hash>
</Codenesium>*/