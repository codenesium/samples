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
	public class EmailAddressRepository: AbstractEmailAddressRepository, IEmailAddressRepository
	{
		public EmailAddressRepository(ILogger<EmailAddressRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFEmailAddress> SearchLinqEF(Expression<Func<EFEmailAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
			else
			{
				return this._context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
		}

		protected override List<EFEmailAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
			else
			{
				return this._context.Set<EFEmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFEmailAddress>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e1b14c67ff5942e2c6f1cd0c1454e351</Hash>
</Codenesium>*/