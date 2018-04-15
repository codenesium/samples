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
	public class PhoneNumberTypeRepository: AbstractPhoneNumberTypeRepository, IPhoneNumberTypeRepository
	{
		public PhoneNumberTypeRepository(
			IObjectMapper mapper,
			ILogger<PhoneNumberTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPhoneNumberType> SearchLinqEF(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("PhoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this.context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}

		protected override List<EFPhoneNumberType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("PhoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this.context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>cdb68425e62ce028be3954e493bf56c3</Hash>
</Codenesium>*/