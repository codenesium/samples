using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		int Create(string name,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int addressTypeID, string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int addressTypeID);

		Response GetById(int addressTypeID);

		POCOAddressType GetByIdDirect(int addressTypeID);

		Response GetWhere(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fe3db53ff8e929fa80d6169918a19211</Hash>
</Codenesium>*/