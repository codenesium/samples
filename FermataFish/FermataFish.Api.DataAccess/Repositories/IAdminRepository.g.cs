using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface IAdminRepository
	{
		Task<Admin> Create(Admin item);

		Task Update(Admin item);

		Task Delete(int id);

		Task<Admin> Get(int id);

		Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>3ebad8056959c148c8f1878a07d0ce94</Hash>
</Codenesium>*/