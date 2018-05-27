using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		Task<DTOPersonPhone> Create(DTOPersonPhone dto);

		Task Update(int businessEntityID,
		            DTOPersonPhone dto);

		Task Delete(int businessEntityID);

		Task<DTOPersonPhone> Get(int businessEntityID);

		Task<List<DTOPersonPhone>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOPersonPhone>> GetPhoneNumber(string phoneNumber);
	}
}

/*<Codenesium>
    <Hash>77a2af40d8770379e3b00857bb50bc87</Hash>
</Codenesium>*/