using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		int Create(
			string addressLine1,
			string addressLine2,
			string city,
			int stateProvinceID,
			string postalCode,
			object spatialLocation,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int addressID,
		            string addressLine1,
		            string addressLine2,
		            string city,
		            int stateProvinceID,
		            string postalCode,
		            object spatialLocation,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int addressID);

		Response GetById(int addressID);

		POCOAddress GetByIdDirect(int addressID);

		Response GetWhere(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAddress> GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>61176128ab33b850732162062a443bac</Hash>
</Codenesium>*/