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
	public class AddressRepository: AbstractAddressRepository, IAddressRepository
	{
		public AddressRepository(
			IObjectMapper mapper,
			ILogger<AddressRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFAddress> SearchLinqEF(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy("AddressID ASC").Skip(skip).Take(take).ToList<EFAddress>();
			}
			else
			{
				return this.context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddress>();
			}
		}

		protected override List<EFAddress> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy("AddressID ASC").Skip(skip).Take(take).ToList<EFAddress>();
			}
			else
			{
				return this.context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddress>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>bd2472c4ac3b6ea586008a3dc822ec6d</Hash>
</Codenesium>*/