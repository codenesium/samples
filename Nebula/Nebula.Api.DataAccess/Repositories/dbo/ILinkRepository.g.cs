using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		int Create(Nullable<int> assignedMachineId,
		           int chainId,
		           Nullable<DateTime> dateCompleted,
		           Nullable<DateTime> dateStarted,
		           string dynamicParameters,
		           Guid externalId,
		           int linkStatusId,
		           string name,
		           int order,
		           string response,
		           string staticParameters);

		void Update(int id, Nullable<int> assignedMachineId,
		            int chainId,
		            Nullable<DateTime> dateCompleted,
		            Nullable<DateTime> dateStarted,
		            string dynamicParameters,
		            Guid externalId,
		            int linkStatusId,
		            string name,
		            int order,
		            string response,
		            string staticParameters);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Link, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>771cff05690d71d130d0a79a4d8ebc6c</Hash>
</Codenesium>*/