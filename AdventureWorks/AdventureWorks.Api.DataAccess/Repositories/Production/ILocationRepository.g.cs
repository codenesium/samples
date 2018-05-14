using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ILocationRepository
	{
		POCOLocation Create(ApiLocationModel model);

		void Update(short locationID,
		            ApiLocationModel model);

		void Delete(short locationID);

		POCOLocation Get(short locationID);

		List<POCOLocation> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOLocation GetName(string name);
	}
}

/*<Codenesium>
    <Hash>afb84692dd84b53e2153df6ff8f9da70</Hash>
</Codenesium>*/