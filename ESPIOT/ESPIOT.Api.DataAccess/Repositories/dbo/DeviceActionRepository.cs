using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public class DeviceActionRepository: AbstractDeviceActionRepository, IDeviceActionRepository
	{
		public DeviceActionRepository(ILogger<DeviceActionRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFDeviceAction> SearchLinqEF(Expression<Func<EFDeviceAction, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDeviceAction>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFDeviceAction>();
			}
			else
			{
				return this._context.Set<EFDeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDeviceAction>();
			}
		}

		protected override List<EFDeviceAction> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDeviceAction>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFDeviceAction>();
			}
			else
			{
				return this._context.Set<EFDeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDeviceAction>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>8dfa165fe0dfb27ecbcc23abff11ab48</Hash>
</Codenesium>*/