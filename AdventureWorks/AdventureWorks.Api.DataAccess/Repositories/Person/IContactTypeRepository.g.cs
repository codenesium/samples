using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		int Create(string name,
		           DateTime modifiedDate);

		void Update(int contactTypeID, string name,
		            DateTime modifiedDate);

		void Delete(int contactTypeID);

		void GetById(int contactTypeID, Response response);

		void GetWhere(Expression<Func<EFContactType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>186811656f1cf12dd1267151d829ca71</Hash>
</Codenesium>*/