using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ITeamRepository
	{
		int Create(string name,
		           int organizationId);

		void Update(int id, string name,
		            int organizationId);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Team, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>90959ad5cf3eea12728a54819adde575</Hash>
</Codenesium>*/