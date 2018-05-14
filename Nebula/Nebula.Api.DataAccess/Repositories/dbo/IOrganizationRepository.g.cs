using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		POCOOrganization Create(ApiOrganizationModel model);

		void Update(int id,
		            ApiOrganizationModel model);

		void Delete(int id);

		POCOOrganization Get(int id);

		List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOOrganization Name(string name);
	}
}

/*<Codenesium>
    <Hash>0f32e01dc485562371e60911f6c61d57</Hash>
</Codenesium>*/