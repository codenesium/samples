using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		int Create(string description,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productDescriptionID, string description,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productDescriptionID);

		void GetById(int productDescriptionID, Response response);

		void GetWhere(Expression<Func<EFProductDescription, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>32496ed7a169e47847bc9e3791c3948d</Hash>
</Codenesium>*/