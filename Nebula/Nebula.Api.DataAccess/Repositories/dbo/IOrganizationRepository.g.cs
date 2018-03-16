using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Organization, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e200c86de9295f00591898b2828b6726</Hash>
</Codenesium>*/