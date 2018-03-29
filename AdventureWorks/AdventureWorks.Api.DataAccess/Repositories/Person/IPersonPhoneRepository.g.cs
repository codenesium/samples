using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		int Create(string phoneNumber,
		           int phoneNumberTypeID,
		           DateTime modifiedDate);

		void Update(int businessEntityID, string phoneNumber,
		            int phoneNumberTypeID,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFPersonPhone, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8173cf08550f689b88b85d3618ac6f8f</Hash>
</Codenesium>*/