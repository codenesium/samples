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
				return this._context.Set<EFMachine>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFMachine>();
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
				return this._context.Set<EFMachine>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFMachine>();
			}
			else
			{
				return this._context.Set<EFMachine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFMachine>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>dd7f1ea1c0b4550ef9ea50e83624cb92</Hash>
</Codenesium>*/