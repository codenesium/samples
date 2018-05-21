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

		Task<POCOFile> Get(int id);

		Task<List<POCOFile>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>16a6cac480ffc645c7b7f5e35cb2e90f</Hash>
</Codenesium>*/