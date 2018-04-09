using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int id);

		POCOChain GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOChain> GetWhereDirect(Expression<Func<EFChain, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cd6b0454b21b59bd89115e86d63deeff</Hash>
</Codenesium>*/