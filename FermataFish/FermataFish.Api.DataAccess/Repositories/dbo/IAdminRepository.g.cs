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

		ApiResponse GetById(int id);

		POCOAdmin GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAdmin> GetWhereDirect(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d717e07af7bbc7962dc1b497cede2bbb</Hash>
</Codenesium>*/