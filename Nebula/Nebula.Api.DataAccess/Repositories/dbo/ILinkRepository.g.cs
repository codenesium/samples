using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int id);

		POCOLink GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOLink> GetWhereDirect(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>da15f35a1b8784d7c28dfe3ffcf4551e</Hash>
</Codenesium>*/