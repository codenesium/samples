using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPersonPhoneRepository
	{
		Task<PersonPhone> Create(PersonPhone item);

		Task Update(PersonPhone item);

		Task Delete(int businessEntityID);

		Task<PersonPhone> Get(int businessEntityID);

		Task<List<PersonPhone>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PersonPhone>> ByPhoneNumber(string phoneNumber, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>73035f8ba26355d640b22e493f22c22c</Hash>
</Codenesium>*/