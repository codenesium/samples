using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		Task<POCOPersonPhone> Create(ApiPersonPhoneModel model);

		Task Update(int businessEntityID,
		            ApiPersonPhoneModel model);

		Task Delete(int businessEntityID);

		Task<POCOPersonPhone> Get(int businessEntityID);

		Task<List<POCOPersonPhone>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPersonPhone>> GetPhoneNumber(string phoneNumber);
	}
}

/*<Codenesium>
    <Hash>748ac44ee55c2d1c3f063916d25e0e9c</Hash>
</Codenesium>*/