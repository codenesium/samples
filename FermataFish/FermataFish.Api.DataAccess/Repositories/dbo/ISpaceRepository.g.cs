using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceRepository
	{
		POCOSpace Create(ApiSpaceModel model);

		void Update(int id,
		            ApiSpaceModel model);

		void Delete(int id);

		POCOSpace Get(int id);

		List<POCOSpace> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>09fab77416f806272cd6a7d3f5219c1d</Hash>
</Codenesium>*/