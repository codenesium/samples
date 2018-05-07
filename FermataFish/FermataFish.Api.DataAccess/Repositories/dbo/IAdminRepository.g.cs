using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IAdminRepository
	{
		int Create(AdminModel model);

		void Update(int id,
		            AdminModel model);

		void Delete(int id);

		POCOAdmin Get(int id);

		List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4e76584d3118703ee875386f83d58976</Hash>
</Codenesium>*/