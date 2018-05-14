using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IAdminRepository
	{
		POCOAdmin Create(ApiAdminModel model);

		void Update(int id,
		            ApiAdminModel model);

		void Delete(int id);

		POCOAdmin Get(int id);

		List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1ce4552b15b10d6ef40d7eb9fbd9f66f</Hash>
</Codenesium>*/