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

		protected override List<EFDevice> SearchLinqEF(Expression<Func<EFDevice, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDevice>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFDevice>();
			}
			else
			{
				return this._context.Set<EFDevice>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDevice>();
			}
		}

		protected override List<EFDevice> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFDevice>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFDevice>();
			}
			else
			{
				return this._context.Set<EFDevice>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDevice>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>aece176976ba32f0e081d3b2a6322b12</Hash>
</Codenesium>*/