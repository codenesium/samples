using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		POCOOrganization Create(OrganizationModel model);

		void Update(int id,
		            OrganizationModel model);

		void Delete(int id);

		POCOOrganization Get(int id);

		List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOOrganization Name(string name);
	}
}

/*<Codenesium>
    <Hash>4d2cc7c2683ba618082a8d7d2225e0e7</Hash>
</Codenesium>*/