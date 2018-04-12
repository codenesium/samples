using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		int Create(
			string name,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int addressTypeID,
		            string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int addressTypeID);

		Response GetById(int addressTypeID);

		POCOAddressType GetByIdDirect(int addressTypeID);

		Response GetWhere(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3b21e760babeee845819446576b27764</Hash>
</Codenesium>*/