using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		int Create(FileModel model);

		void Update(int id,
		            FileModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOFile GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFile> GetWhereDirect(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b58f1f3a5f3bb824e62a6780d8bf9a47</Hash>
</Codenesium>*/