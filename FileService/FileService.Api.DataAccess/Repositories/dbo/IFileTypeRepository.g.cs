using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		Response GetById(int id);

		POCOFileType GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOFileType> GetWhereDirect(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9887650651e30283413856cbd4e9e4ac</Hash>
</Codenesium>*/