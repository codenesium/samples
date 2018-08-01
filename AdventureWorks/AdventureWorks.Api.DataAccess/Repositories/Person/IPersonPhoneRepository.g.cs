using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		Task<PersonPhone> Create(PersonPhone item);

		Task Update(PersonPhone item);

		Task Delete(int businessEntityID);

		Task<PersonPhone> Get(int businessEntityID);

		Task<List<PersonPhone>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PersonPhone>> ByPhoneNumber(string phoneNumber);
	}
}

/*<Codenesium>
    <Hash>2eb89d0af1d57a2e24f670e2c27c6eb5</Hash>
</Codenesium>*/