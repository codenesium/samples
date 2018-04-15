using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityRepository
	{
		int Create(BusinessEntityModel model);

		void Update(int businessEntityID,
		            BusinessEntityModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOBusinessEntity GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntity> GetWhereDirect(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9530f377605565ea20bc25cfe1b219d2</Hash>
</Codenesium>*/