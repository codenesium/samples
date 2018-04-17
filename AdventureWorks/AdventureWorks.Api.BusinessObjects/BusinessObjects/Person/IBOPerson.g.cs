using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPerson
	{
		Task<CreateResponse<int>> Create(
			PersonModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            PersonModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOPerson GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPerson> GetWhereDirect(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8d749625bebc36d0861a20f41af0eceb</Hash>
</Codenesium>*/