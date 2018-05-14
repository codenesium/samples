using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOFamily
	{
		Task<CreateResponse<POCOFamily>> Create(
			ApiFamilyModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFamilyModel model);

		Task<ActionResponse> Delete(int id);

		POCOFamily Get(int id);

		List<POCOFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>be353f40faeadd8731b2cd0c91d93ed1</Hash>
</Codenesium>*/