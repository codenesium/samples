using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class FileRepository: AbstractFileRepository, IFileRepository
	{
		public FileRepository(ILogger<FileRepository> logger,
		                      ApplicationContext context) : base(logger,context)
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
    <Hash>e30934368b7866a5b6f31f32630bd7f8</Hash>
</Codenesium>*/