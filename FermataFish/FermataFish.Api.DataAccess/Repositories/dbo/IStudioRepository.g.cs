using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudioRepository
	{
		POCOStudio Create(ApiStudioModel model);

		void Update(int id,
		            ApiStudioModel model);

		void Delete(int id);

		POCOStudio Get(int id);

		List<POCOStudio> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8378c4c86c2e2186af66dc7668a68189</Hash>
</Codenesium>*/