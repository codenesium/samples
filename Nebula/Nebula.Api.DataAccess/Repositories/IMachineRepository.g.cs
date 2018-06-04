using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		Task<Machine> Create(Machine item);

		Task Update(Machine item);

		Task Delete(int id);

		Task<Machine> Get(int id);

		Task<List<Machine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>13b9005c92cf94e6e69868c7515b963d</Hash>
</Codenesium>*/