using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		int Create(int chainStatusId,
		           Guid externalId,
		           string name,
		           int teamId);

		void Update(int id, int chainStatusId,
		            Guid externalId,
		            string name,
		            int teamId);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Chain, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fbebf13ced7a2fd379fb6e90744be6af</Hash>
</Codenesium>*/