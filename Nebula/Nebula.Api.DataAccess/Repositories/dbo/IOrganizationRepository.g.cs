using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		Response GetById(int id);

		POCOOrganization GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOOrganization> GetWhereDirect(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ede170ecc19167723d8561f3280b2c33</Hash>
</Codenesium>*/