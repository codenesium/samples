using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		int Create(FileTypeModel model);

		void Update(int id,
		            FileTypeModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOFileType GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFileType> GetWhereDirect(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>14004fde4d3a8797559d3f46a0b2a34b</Hash>
</Codenesium>*/