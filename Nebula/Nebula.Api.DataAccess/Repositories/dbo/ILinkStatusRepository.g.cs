using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFLinkStatus, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5a4b32d54320ce6a2ff8df003eb89f16</Hash>
</Codenesium>*/