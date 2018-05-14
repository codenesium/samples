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
			FileModel model);

		Task<ActionResponse> Update(int id,
		                            FileModel model);

		Task<ActionResponse> Delete(int id);

		POCOFile Get(int id);

		List<POCOFile> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>947eea3fa2b21d98e36fdfd0f245091f</Hash>
</Codenesium>*/