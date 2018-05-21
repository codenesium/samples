using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		Task<POCOEmailAddress> Create(ApiEmailAddressModel model);

		Task Update(int businessEntityID,
		            ApiEmailAddressModel model);

		Task Delete(int businessEntityID);

		Task<POCOEmailAddress> Get(int businessEntityID);

		Task<List<POCOEmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOEmailAddress>> GetEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>2d8faa557522f92d8011c48b0ea30da3</Hash>
</Codenesium>*/