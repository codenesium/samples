using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		int Create(int nextChainId,
		           int previousChainId);

		void Update(int id, int nextChainId,
		            int previousChainId);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Clasp, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>11c2d629c2af6dd41323062c6ad711b4</Hash>
</Codenesium>*/