using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IAdminRepository
	{
		POCOAdmin Create(AdminModel model);

		void Update(int id,
		            AdminModel model);

		void Delete(int id);

		POCOAdmin Get(int id);

		List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3d205dbea3a02809dcda7c64dbb94680</Hash>
</Codenesium>*/