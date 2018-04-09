using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int stateProvinceID);

		POCOStateProvince GetByIdDirect(int stateProvinceID);

		Response GetWhere(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOStateProvince> GetWhereDirect(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c56c3d41c71f3f40ea5adf7dfc727f0f</Hash>
</Codenesium>*/