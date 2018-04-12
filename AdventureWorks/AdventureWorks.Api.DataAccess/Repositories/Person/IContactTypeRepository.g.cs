using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		int Create(
			string name,
			DateTime modifiedDate);

		void Update(int contactTypeID,
		            string name,
		            DateTime modifiedDate);

		void Delete(int contactTypeID);

		Response GetById(int contactTypeID);

		POCOContactType GetByIdDirect(int contactTypeID);

		Response GetWhere(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOContactType> GetWhereDirect(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>712d60466c96c1c60a18f0cd44c2712e</Hash>
</Codenesium>*/