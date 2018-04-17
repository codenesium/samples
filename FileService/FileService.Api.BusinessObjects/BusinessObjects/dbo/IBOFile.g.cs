using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOFile
	{
		Task<CreateResponse<int>> Create(
			FileModel model);

		Task<ActionResponse> Update(int id,
		                            FileModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOFile GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFile> GetWhereDirect(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>da8f6ae0bb64f577173ee0ef571874ea</Hash>
</Codenesium>*/