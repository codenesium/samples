using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		POCOMachine Create(MachineModel model);

		void Update(int id,
		            MachineModel model);

		void Delete(int id);

		POCOMachine Get(int id);

		List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOMachine MachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>84bb770f50b93a6f946220e594d21c3f</Hash>
</Codenesium>*/