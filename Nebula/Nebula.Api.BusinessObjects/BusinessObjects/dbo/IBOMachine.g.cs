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
		Task<CreateResponse<POCOMachine>> Create(
			MachineModel model);

		Task<ActionResponse> Update(int id,
		                            MachineModel model);

		Task<ActionResponse> Delete(int id);

		POCOMachine Get(int id);

		List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOMachine MachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>82042d0f9daebbc151a395ea34f58159</Hash>
</Codenesium>*/