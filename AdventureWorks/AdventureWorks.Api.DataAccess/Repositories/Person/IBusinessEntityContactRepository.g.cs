using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityContactRepository
	{
		int Create(int personID,
		           int contactTypeID,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, int personID,
		            int contactTypeID,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOBusinessEntityContact GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOBusinessEntityContact> GetWhereDirect(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bb128010c6abdd86c93c884debda1a1d</Hash>
</Codenesium>*/