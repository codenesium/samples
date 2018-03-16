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
	public class DeviceRepository: AbstractDeviceRepository, IDeviceRepository
	{
		public DeviceRepository(ILogger<DeviceRepository> logger,
		                        ApplicationContext context) : base(logger,context)
		{}

		protected override List<Device> SearchLinqEF(Expression<Func<Device, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Device>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Device>();
			}
			else
			{
				return this._context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Device>();
			}
		}

		protected override List<Device> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Device>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Device>();
			}
			else
			{
				return this._context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Device>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>058898c2439b72a2fe9ee75b3b88e5ef</Hash>
</Codenesium>*/