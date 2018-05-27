using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStoreRepository
	{
		Task<DTOStore> Create(DTOStore dto);

		Task Update(int businessEntityID,
		            DTOStore dto);

		Task Delete(int businessEntityID);

		Task<DTOStore> Get(int businessEntityID);

		Task<List<DTOStore>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOStore>> GetSalesPersonID(Nullable<int> salesPersonID);
		Task<List<DTOStore>> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>63ae4c97d1d4a37c56e827ceb3432485</Hash>
</Codenesium>*/