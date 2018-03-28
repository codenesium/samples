using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		int Create(int linkId,
		           string log,
		           DateTime dateEntered);

		void Update(int id, int linkId,
		            string log,
		            DateTime dateEntered);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFLinkLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d18d99999297ee267812c221e2d568c7</Hash>
</Codenesium>*/