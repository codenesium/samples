using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		int Create(int previousChainId,
		           int nextChainId);

		void Update(int id, int previousChainId,
		            int nextChainId);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFClasp, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a7749da5e216dc31683429aeace89dad</Hash>
</Codenesium>*/