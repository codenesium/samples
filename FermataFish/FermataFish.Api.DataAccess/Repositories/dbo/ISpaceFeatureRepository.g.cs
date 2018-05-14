using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceFeatureRepository
	{
		POCOSpaceFeature Create(SpaceFeatureModel model);

		void Update(int id,
		            SpaceFeatureModel model);

		void Delete(int id);

		POCOSpaceFeature Get(int id);

		List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f64953db524cdaf31c7fa83901a82439</Hash>
</Codenesium>*/