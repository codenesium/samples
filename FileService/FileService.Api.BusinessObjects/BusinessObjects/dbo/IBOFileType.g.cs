using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOFileType
	{
		Task<CreateResponse<int>> Create(
			FileTypeModel model);

		Task<ActionResponse> Update(int id,
		                            FileTypeModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOFileType GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOFileType> GetWhereDirect(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>13eab2c17d34b625e0ce089e1de840ec</Hash>
</Codenesium>*/