using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class MachineRepository: AbstractMachineRepository
	{
		public MachineRepository(ILogger logger,
		                         DbContext context) : base(logger,context)
		{}

		protected override List<Machine> SearchLinqEF(Expression<Func<Machine, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Machine>();
			}
			else
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Machine>();
			}
		}

		protected override List<Machine> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Machine>();
			}
			else
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Machine>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>42399b1d6b6533f7b9034c6debdbd9e0</Hash>
</Codenesium>*/