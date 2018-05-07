using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ILocationRepository
	{
		short Create(LocationModel model);

		void Update(short locationID,
		            LocationModel model);

		void Delete(short locationID);

		POCOLocation Get(short locationID);

		List<POCOLocation> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>75385155d585649f292a29750aba06ab</Hash>
</Codenesium>*/