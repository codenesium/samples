using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public class PaymentTypeRepository: AbstractPaymentTypeRepository, IPaymentTypeRepository
	{
		public PaymentTypeRepository(
			IObjectMapper mapper,
			ILogger<PaymentTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFPaymentType> SearchLinqEF(Expression<Func<EFPaymentType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPaymentType>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPaymentType>();
			}
			else
			{
				return this.Context.Set<EFPaymentType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPaymentType>();
			}
		}

		protected override List<EFPaymentType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFPaymentType>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFPaymentType>();
			}
			else
			{
				return this.Context.Set<EFPaymentType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPaymentType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>667b24c8388227c6b9ea440b56e90b37</Hash>
</Codenesium>*/