using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceRepository
	{
		POCOSpace Create(SpaceModel model);

		void Update(int id,
		            SpaceModel model);

		void Delete(int id);

		POCOSpace Get(int id);

		List<POCOSpace> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>739b12b33b280e9e69f82795424b8c7a</Hash>
</Codenesium>*/