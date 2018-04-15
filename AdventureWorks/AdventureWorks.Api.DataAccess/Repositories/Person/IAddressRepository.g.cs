using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		int Create(AddressModel model);

		void Update(int addressID,
		            AddressModel model);

		void Delete(int addressID);

		ApiResponse GetById(int addressID);

		POCOAddress GetByIdDirect(int addressID);

		ApiResponse GetWhere(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAddress> GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7cf22437860af755316af672edd0624f</Hash>
</Codenesium>*/