using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOTeacher
	{
		Task<CreateResponse<ApiTeacherResponseModel>> Create(
			ApiTeacherRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherResponseModel> Get(int id);

		Task<List<ApiTeacherResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae36fc6828583853009213435d38d121</Hash>
</Codenesium>*/