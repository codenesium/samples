using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		int Create(string description,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productDescriptionID, string description,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productDescriptionID);

		Response GetById(int productDescriptionID);

		POCOProductDescription GetByIdDirect(int productDescriptionID);

		Response GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f5c9942333aeab356c7ce89535088f87</Hash>
</Codenesium>*/