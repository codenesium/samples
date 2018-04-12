using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		int Create(
			string description,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int productDescriptionID,
		            string description,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productDescriptionID);

		Response GetById(int productDescriptionID);

		POCOProductDescription GetByIdDirect(int productDescriptionID);

		Response GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>942e67be17bd7364c45e899de4baa106</Hash>
</Codenesium>*/