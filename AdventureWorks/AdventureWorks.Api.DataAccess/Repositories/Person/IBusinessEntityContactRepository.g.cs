using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityContactRepository
	{
		Task<POCOBusinessEntityContact> Create(ApiBusinessEntityContactModel model);

		Task Update(int businessEntityID,
		            ApiBusinessEntityContactModel model);

		Task Delete(int businessEntityID);

		Task<POCOBusinessEntityContact> Get(int businessEntityID);

		Task<List<POCOBusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOBusinessEntityContact>> GetContactTypeID(int contactTypeID);
		Task<List<POCOBusinessEntityContact>> GetPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>7183d173da89ce7a1894cf52a0cee195</Hash>
</Codenesium>*/