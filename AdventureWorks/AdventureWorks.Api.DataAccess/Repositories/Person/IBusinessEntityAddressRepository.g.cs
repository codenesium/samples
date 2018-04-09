using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int businessEntityID);

		POCOBusinessEntityAddress GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOBusinessEntityAddress> GetWhereDirect(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ac5d2ed281e56fc1c42bbfe0c2e95e93</Hash>
</Codenesium>*/