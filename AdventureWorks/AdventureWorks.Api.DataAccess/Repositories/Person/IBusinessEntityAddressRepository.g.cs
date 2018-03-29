using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		int Create(int addressID,
		           int addressTypeID,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, int addressID,
		            int addressTypeID,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFBusinessEntityAddress, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dc78a4eb5e011e6bb17bc084443a0e33</Hash>
</Codenesium>*/