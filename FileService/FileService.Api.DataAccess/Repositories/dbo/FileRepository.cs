using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class FileRepository: AbstractFileRepository
	{
		public FileRepository(ILogger logger,
		                      DbContext context) : base(logger,context)
		{}

		protected override List<File> SearchLinqEF(Expression<Func<File, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<File>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<File>();
			}
			else
			{
				return this._context.Set<File>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<File>();
			}
		}

		protected override List<File> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<File>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<File>();
			}
			else
			{
				return this._context.Set<File>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<File>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6a5f8c9c385d18cf708235771a58eb31</Hash>
</Codenesium>*/