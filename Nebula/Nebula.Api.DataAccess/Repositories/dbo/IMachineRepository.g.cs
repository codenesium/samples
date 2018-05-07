using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		int Create(MachineModel model);

		void Update(int id,
		            MachineModel model);

		void Delete(int id);

		POCOMachine Get(int id);

		List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9950467e5f5bdd53be635edf21a94470</Hash>
</Codenesium>*/