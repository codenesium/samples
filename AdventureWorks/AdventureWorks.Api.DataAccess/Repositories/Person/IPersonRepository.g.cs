using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonRepository
	{
		int Create(PersonModel model);

		void Update(int businessEntityID,
		            PersonModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOPerson GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPerson> GetWhereDirect(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a1abaab88fc8aeccf7d8f6509552f487</Hash>
</Codenesium>*/