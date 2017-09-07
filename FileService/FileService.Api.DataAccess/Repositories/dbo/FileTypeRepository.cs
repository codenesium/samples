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
	public class FileTypeRepository: AbstractFileTypeRepository
	{
		public FileTypeRepository(ILogger logger,
		                          DbContext context) : base(logger,context)
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
    <Hash>f11388a06319054bb90cdca3ff1e0dbf</Hash>
</Codenesium>*/