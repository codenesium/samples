using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		int Create(string addressLine1,
		           string addressLine2,
		           string city,
		           int stateProvinceID,
		           string postalCode,
		           object spatialLocation,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int addressID, string addressLine1,
		            string addressLine2,
		            string city,
		            int stateProvinceID,
		            string postalCode,
		            object spatialLocation,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int addressID);

		void GetById(int addressID, Response response);

		void GetWhere(Expression<Func<EFAddress, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>453cf96dcff979aa6b0c2dbb2ba41fc9</Hash>
</Codenesium>*/