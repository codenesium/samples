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
	public class AddressTypeRepository: AbstractAddressTypeRepository, IAddressTypeRepository
	{
		public AddressTypeRepository(
			IObjectMapper mapper,
			ILogger<AddressTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFAddressType> SearchLinqEF(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy("AddressTypeID ASC").Skip(skip).Take(take).ToList<EFAddressType>();
			}
			else
			{
				return this.context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddressType>();
			}
		}

		protected override List<EFAddressType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy("AddressTypeID ASC").Skip(skip).Take(take).ToList<EFAddressType>();
			}
			else
			{
				return this.context.Set<EFAddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddressType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>b47ad6cec713e63064d067b0ae68e389</Hash>
</Codenesium>*/