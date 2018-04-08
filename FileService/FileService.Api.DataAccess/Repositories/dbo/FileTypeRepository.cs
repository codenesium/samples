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
		                          ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFFileType> SearchLinqEF(Expression<Func<EFFileType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFFileType>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFFileType>();
			}
			else
			{
				return this.context.Set<EFFileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFFileType>();
			}
		}

		protected override List<EFFileType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFFileType>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFFileType>();
			}
			else
			{
				return this.context.Set<EFFileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFFileType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f0ead0fc764c0b479164e45cfc484bba</Hash>
</Codenesium>*/