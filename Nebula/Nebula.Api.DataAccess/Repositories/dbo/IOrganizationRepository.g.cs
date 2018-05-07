using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		int Create(OrganizationModel model);

		void Update(int id,
		            OrganizationModel model);

		void Delete(int id);

		POCOOrganization Get(int id);

		List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>97b1a0a5a895740e98f38d6bc934d7d2</Hash>
</Codenesium>*/