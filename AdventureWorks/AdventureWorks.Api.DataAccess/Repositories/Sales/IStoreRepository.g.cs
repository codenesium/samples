using System;
using System.Linq.Expressions;
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

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFStore, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0c1227128722e6231c9dfca9518aa8e4</Hash>
</Codenesium>*/