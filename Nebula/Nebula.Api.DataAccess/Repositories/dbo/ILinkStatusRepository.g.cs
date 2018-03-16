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

		void GetWhere(Expression<Func<LinkStatus, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>45f64ed1a5f70153f86a71963909f539</Hash>
</Codenesium>*/