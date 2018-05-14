using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		POCOMachine Create(ApiMachineModel model);

		void Update(int id,
		            ApiMachineModel model);

		void Delete(int id);

		POCOMachine Get(int id);

		List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOMachine MachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>9f089c7734a6ba0de01fd61a67c6f32a</Hash>
</Codenesium>*/