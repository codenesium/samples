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
	public class DeviceActionRepository: AbstractDeviceActionRepository
	{
		public DeviceActionRepository(ILogger<DeviceActionRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<DeviceAction> SearchLinqEF(Expression<Func<DeviceAction, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<DeviceAction>();
			}
			else
			{
				return this._context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<DeviceAction>();
			}
		}

		protected override List<DeviceAction> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<DeviceAction>();
			}
			else
			{
				return this._context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<DeviceAction>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>77c0d59627d03a0d926c372ad17c0592</Hash>
</Codenesium>*/