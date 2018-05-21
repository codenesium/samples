using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		Task<POCOContactType> Create(ApiContactTypeModel model);

		Task Update(int contactTypeID,
		            ApiContactTypeModel model);

		Task Delete(int contactTypeID);

		Task<POCOContactType> Get(int contactTypeID);

		Task<List<POCOContactType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOContactType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>a0142b0c6e4a87f0ef95e84e812938bd</Hash>
</Codenesium>*/