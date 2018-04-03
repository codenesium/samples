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
	public class BillOfMaterialsRepository: AbstractBillOfMaterialsRepository, IBillOfMaterialsRepository
	{
		public BillOfMaterialsRepository(ILogger<BillOfMaterialsRepository> logger,
		                                 ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy("billOfMaterialsID ASC").Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
			else
			{
				return this._context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
		}

		protected override List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy("billOfMaterialsID ASC").Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
			else
			{
				return this._context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e7b15f49cac1f41f09988e892bf2decb</Hash>
</Codenesium>*/