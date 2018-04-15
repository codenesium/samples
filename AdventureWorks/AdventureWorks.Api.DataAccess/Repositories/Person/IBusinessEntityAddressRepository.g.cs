using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		int Create(BusinessEntityAddressModel model);

		void Update(int businessEntityID,
		            BusinessEntityAddressModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOBusinessEntityAddress GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntityAddress> GetWhereDirect(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c8e17c242684a48d3387e50660e3fb52</Hash>
</Codenesium>*/