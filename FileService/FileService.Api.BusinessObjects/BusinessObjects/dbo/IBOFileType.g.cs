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

		POCOFileType Get(int id);

		List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>982565672bbc02e2f60eb5b95fa84d24</Hash>
</Codenesium>*/