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

		POCOFileType Get(int id);

		List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fbdf21ba88faf91a80a6f0d8ec16bf49</Hash>
</Codenesium>*/