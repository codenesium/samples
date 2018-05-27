using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ILocationRepository
	{
		Task<DTOLocation> Create(DTOLocation dto);

		Task Update(short locationID,
		            DTOLocation dto);

		Task Delete(short locationID);

		Task<DTOLocation> Get(short locationID);

		Task<List<DTOLocation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOLocation> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>8fe54fe9bd10f0cff99018e87d5daa37</Hash>
</Codenesium>*/