using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		int Create(
			string name,
			int teamId,
			int chainStatusId,
			Guid externalId);

		void Update(int id,
		            string name,
		            int teamId,
		            int chainStatusId,
		            Guid externalId);

		void Delete(int id);

		Response GetById(int id);

		POCOChain GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOChain> GetWhereDirect(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8724b95eaa17cc362d634f0fb6828ac9</Hash>
</Codenesium>*/