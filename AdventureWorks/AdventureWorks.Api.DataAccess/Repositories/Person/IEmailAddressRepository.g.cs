using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		Task<DTOEmailAddress> Create(DTOEmailAddress dto);

		Task Update(int businessEntityID,
		            DTOEmailAddress dto);

		Task Delete(int businessEntityID);

		Task<DTOEmailAddress> Get(int businessEntityID);

		Task<List<DTOEmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOEmailAddress>> GetEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>a85406306641f4a62704dc89c9fadcbe</Hash>
</Codenesium>*/