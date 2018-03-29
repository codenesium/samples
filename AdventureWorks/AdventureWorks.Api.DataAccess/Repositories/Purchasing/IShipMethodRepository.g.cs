using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		int Create(string name,
		           decimal shipBase,
		           decimal shipRate,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int shipMethodID, string name,
		            decimal shipBase,
		            decimal shipRate,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int shipMethodID);

		void GetById(int shipMethodID, Response response);

		void GetWhere(Expression<Func<EFShipMethod, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>298b351d8b280cf63b456824c5b260be</Hash>
</Codenesium>*/