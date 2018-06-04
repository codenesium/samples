using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface IAdminRepository
	{
		Task<Admin> Create(Admin item);

		Task Update(Admin item);

		Task Delete(int id);

		Task<Admin> Get(int id);

		Task<List<Admin>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f8c86c99a92ecbce7f1bccd856560931</Hash>
</Codenesium>*/