using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainStatusRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<ChainStatus, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1f90701ee80cc7e5df61ffe6b93fb503</Hash>
</Codenesium>*/