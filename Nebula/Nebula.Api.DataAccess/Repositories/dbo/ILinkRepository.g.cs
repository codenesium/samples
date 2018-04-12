using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		int Create(
			string name,
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

		void Update(int id,
		            string name,
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

		Response GetWhere(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLink> GetWhereDirect(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e83dd232bd5b29990c3663495bb7ce5c</Hash>
</Codenesium>*/