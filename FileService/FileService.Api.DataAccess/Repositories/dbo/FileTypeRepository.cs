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
	public class FileTypeRepository: AbstractFileTypeRepository, IFileTypeRepository
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
    <Hash>7b12603d8da531c113119efb7875e753</Hash>
</Codenesium>*/