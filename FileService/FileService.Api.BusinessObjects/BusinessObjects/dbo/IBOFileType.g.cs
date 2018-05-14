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
			FileTypeModel model);

		Task<ActionResponse> Update(int id,
		                            FileTypeModel model);

		Task<ActionResponse> Delete(int id);

		POCOFileType Get(int id);

		List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f3fb7e9099341fb6f5ba5232902be1df</Hash>
</Codenesium>*/