using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		int Create(ContactTypeModel model);

		void Update(int contactTypeID,
		            ContactTypeModel model);

		void Delete(int contactTypeID);

		ApiResponse GetById(int contactTypeID);

		POCOContactType GetByIdDirect(int contactTypeID);

		ApiResponse GetWhere(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOContactType> GetWhereDirect(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b8bba2a551651e6c8592847d6eeb70bf</Hash>
</Codenesium>*/