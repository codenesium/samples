using System;
using System.Linq.Expressions;
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

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFBusinessEntityContact, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3b2056f705c51cf71742c00d1d236e4d</Hash>
</Codenesium>*/