using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		int Create(string name,
		           string dynamicParameters,
		           string staticParameters,
		           int chainId,
		           Nullable<int> assignedMachineId,
		           int linkStatusId,
		           int order,
		           Nullable<DateTime> dateStarted,
		           Nullable<DateTime> dateCompleted,
		           string response,
		           Guid externalId);

		void Update(int id, string name,
		            string dynamicParameters,
		            string staticParameters,
		            int chainId,
		            Nullable<int> assignedMachineId,
		            int linkStatusId,
		            int order,
		            Nullable<DateTime> dateStarted,
		            Nullable<DateTime> dateCompleted,
		            string response,
		            Guid externalId);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFLink, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d9e3f42cd4218641c3fd8630d8a25b2d</Hash>
</Codenesium>*/