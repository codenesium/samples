using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		int Create(DateTime dateEntered,
		           int linkId,
		           string log);

		void Update(int id, DateTime dateEntered,
		            int linkId,
		            string log);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<LinkLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7690f32f5cfb4beb15a7cc5ef45f5b0c</Hash>
</Codenesium>*/