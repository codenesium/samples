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
		public BillOfMaterialsRepository(
			IObjectMapper mapper,
			ILogger<BillOfMaterialsRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy("BillOfMaterialsID ASC").Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
			else
			{
				return this.context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
		}

		protected override List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
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
    <Hash>422b8f895cf5ee9b2a277368bbea4f93</Hash>
</Codenesium>*/