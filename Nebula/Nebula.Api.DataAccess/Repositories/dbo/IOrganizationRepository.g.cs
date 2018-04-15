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

		ApiResponse GetById(int id);

		POCOOrganization GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOOrganization> GetWhereDirect(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a9bfb9be8567759b2f456b79e99a3230</Hash>
</Codenesium>*/