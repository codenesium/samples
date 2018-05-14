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
		Task<CreateResponse<POCOFile>> Create(
			ApiFileModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFileModel model);

		Task<ActionResponse> Delete(int id);

		POCOFile Get(int id);

		List<POCOFile> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5712c3c1afc7a3a354be506bb038eda4</Hash>
</Codenesium>*/