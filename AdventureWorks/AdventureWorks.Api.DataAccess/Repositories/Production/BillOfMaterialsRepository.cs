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
		                                 ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy("BillOfMaterialsID ASC").Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
			else
			{
				return this.context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
		}

		protected override List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy("BillOfMaterialsID ASC").Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
			else
			{
				return this.context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>bcc67517c368c99b18a45633647791d1</Hash>
</Codenesium>*/