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
			ILogger<AddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
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
    <Hash>d0ac60d61f240c4bcb317bbc42a0284d</Hash>
</Codenesium>*/