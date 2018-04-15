using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		int Create(AddressTypeModel model);

		void Update(int addressTypeID,
		            AddressTypeModel model);

		void Delete(int addressTypeID);

		ApiResponse GetById(int addressTypeID);

		POCOAddressType GetByIdDirect(int addressTypeID);

		ApiResponse GetWhere(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf44570c03c4240f6127115af8705499</Hash>
</Codenesium>*/