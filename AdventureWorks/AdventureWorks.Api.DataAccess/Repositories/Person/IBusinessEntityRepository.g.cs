using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityRepository
	{
		int Create(Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOBusinessEntity GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOBusinessEntity> GetWhereDirect(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b968cb5061cfa111c9e55b59a53daf4f</Hash>
</Codenesium>*/