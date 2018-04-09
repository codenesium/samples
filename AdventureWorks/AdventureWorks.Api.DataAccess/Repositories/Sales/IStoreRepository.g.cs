using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStoreRepository
	{
		int Create(string name,
		           Nullable<int> salesPersonID,
		           string demographics,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, string name,
		            Nullable<int> salesPersonID,
		            string demographics,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOStore GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOStore> GetWhereDirect(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c5848b59e8005242998091e47f7e86de</Hash>
</Codenesium>*/