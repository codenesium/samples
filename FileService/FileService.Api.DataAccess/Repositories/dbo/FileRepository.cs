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
		                      ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFFile> SearchLinqEF(Expression<Func<EFFile, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFFile>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFFile>();
			}
			else
			{
				return this.context.Set<EFFile>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFFile>();
			}
		}

		protected override List<EFFile> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFFile>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFFile>();
			}
			else
			{
				return this.context.Set<EFFile>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFFile>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e2139726532d274d400226a93eab0521</Hash>
</Codenesium>*/