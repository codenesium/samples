using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		int Create(string name,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int addressTypeID, string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int addressTypeID);

		void GetById(int addressTypeID, Response response);

		void GetWhere(Expression<Func<EFAddressType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>84957938a901e7779c08f3f5e0a9aa03</Hash>
</Codenesium>*/