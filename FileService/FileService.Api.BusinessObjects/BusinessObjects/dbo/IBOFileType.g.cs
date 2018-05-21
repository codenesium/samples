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
		Task<CreateResponse<POCOFileType>> Create(
			ApiFileTypeModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFileTypeModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOFileType> Get(int id);

		Task<List<POCOFileType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9721c32a273ff75b626871cf6e1eff60</Hash>
</Codenesium>*/