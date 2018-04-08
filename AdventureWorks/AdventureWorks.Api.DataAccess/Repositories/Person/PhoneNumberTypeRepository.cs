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
		                                 ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFPhoneNumberType> SearchLinqEF(Expression<Func<EFPhoneNumberType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy("PhoneNumberTypeID ASC").Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
			else
			{
				return this.context.Set<EFPhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPhoneNumberType>();
			}
		}

		protected override List<EFPhoneNumberType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
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
    <Hash>c77b06e40863ff5e461c7f06de291ee0</Hash>
</Codenesium>*/