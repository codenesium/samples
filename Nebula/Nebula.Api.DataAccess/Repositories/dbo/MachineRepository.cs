using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class MachineRepository: AbstractMachineRepository, IMachineRepository
	{
		public MachineRepository(ILogger<MachineRepository> logger,
		                         ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFMachine> SearchLinqEF(Expression<Func<EFMachine, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFMachine>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFMachine>();
			}
			else
			{
				return this._context.Set<EFMachine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFMachine>();
			}
		}

		protected override List<EFMachine> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFMachine>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFMachine>();
			}
			else
			{
				return this._context.Set<EFMachine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFMachine>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e341dd392fd9d0bfc1b3036c91e42d62</Hash>
</Codenesium>*/