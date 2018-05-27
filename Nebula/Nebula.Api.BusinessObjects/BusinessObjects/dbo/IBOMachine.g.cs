using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOMachine
	{
		Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiMachineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMachineResponseModel> Get(int id);

		Task<List<ApiMachineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiMachineResponseModel> GetMachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>f3a96e1b037b267cda0c2a0b316ccce6</Hash>
</Codenesium>*/