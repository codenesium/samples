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
		public PhoneNumberTypeRepository(ILogger<PhoneNumberTypeRepository> logger,
		                                 ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFPhoneNumberType> SearchLinqEF(Expression<Func<EFPhoneNumberType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("PhoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this._context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}

		protected override List<EFPhoneNumberType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("PhoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this._context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d8ce24a84932815c68f15d3dc6225d12</Hash>
</Codenesium>*/