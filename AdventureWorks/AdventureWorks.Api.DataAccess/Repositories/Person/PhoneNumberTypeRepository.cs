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
				return this._context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("phoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
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
				return this._context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("phoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this._context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2d096239fdd17019adf5ba4f7808e3b0</Hash>
</Codenesium>*/