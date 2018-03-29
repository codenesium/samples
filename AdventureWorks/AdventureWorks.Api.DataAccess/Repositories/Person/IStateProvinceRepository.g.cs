using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStateProvinceRepository
	{
		int Create(string stateProvinceCode,
		           string countryRegionCode,
		           bool isOnlyStateProvinceFlag,
		           string name,
		           int territoryID,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int stateProvinceID, string stateProvinceCode,
		            string countryRegionCode,
		            bool isOnlyStateProvinceFlag,
		            string name,
		            int territoryID,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int stateProvinceID);

		void GetById(int stateProvinceID, Response response);

		void GetWhere(Expression<Func<EFStateProvince, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c993bdf0cc56ac0a3f97e6a62f36db9b</Hash>
</Codenesium>*/