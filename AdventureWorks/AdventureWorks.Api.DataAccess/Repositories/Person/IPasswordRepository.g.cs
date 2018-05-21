using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		Task<POCOPassword> Create(ApiPasswordModel model);

		Task Update(int businessEntityID,
		            ApiPasswordModel model);

		Task Delete(int businessEntityID);

		Task<POCOPassword> Get(int businessEntityID);

		Task<List<POCOPassword>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>acc22496d2e650bcd76a0b6c62de1a6a</Hash>
</Codenesium>*/