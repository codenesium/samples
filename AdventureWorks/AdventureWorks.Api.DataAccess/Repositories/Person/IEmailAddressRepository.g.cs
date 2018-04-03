using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		int Create(int emailAddressID,
		           string emailAddress,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, int emailAddressID,
		            string emailAddress,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFEmailAddress, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>384c436a7627832bbab40e06ef82e4f9</Hash>
</Codenesium>*/