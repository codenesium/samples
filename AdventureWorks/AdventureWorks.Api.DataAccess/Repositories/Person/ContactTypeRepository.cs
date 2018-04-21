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
	public class ContactTypeRepository: AbstractContactTypeRepository, IContactTypeRepository
	{
		public ContactTypeRepository(
			IObjectMapper mapper,
			ILogger<ContactTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFContactType> SearchLinqEF(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy("ContactTypeID ASC").Skip(skip).Take(take).ToList<EFContactType>();
			}
			else
			{
				return this.Context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFContactType>();
			}
		}

		protected override List<EFContactType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy("ContactTypeID ASC").Skip(skip).Take(take).ToList<EFContactType>();
			}
			else
			{
				return this.Context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFContactType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>1497046e1c0d2b4cc5d4c7f983a6c0e9</Hash>
</Codenesium>*/