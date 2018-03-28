using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		int Create(string name,
		           int teamId,
		           int chainStatusId,
		           Guid externalId);

		void Update(int id, string name,
		            int teamId,
		            int chainStatusId,
		            Guid externalId);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFChain, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>162aeda81f5d18529d3d3f616f3a1270</Hash>
</Codenesium>*/