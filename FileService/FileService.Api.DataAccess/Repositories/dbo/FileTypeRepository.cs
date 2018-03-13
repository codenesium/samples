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
	public class FileTypeRepository: AbstractFileTypeRepository
	{
		public FileTypeRepository(ILogger<FileTypeRepository> logger,
		                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<FileType> SearchLinqEF(Expression<Func<FileType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<FileType>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<FileType>();
			}
			else
			{
				return this._context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<FileType>();
			}
		}

		protected override List<FileType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<FileType>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<FileType>();
			}
			else
			{
				return this._context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<FileType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>924c6355ddcd0e310234b49e8c276b5e</Hash>
</Codenesium>*/