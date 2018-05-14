using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudioRepository
	{
		POCOStudio Create(StudioModel model);

		void Update(int id,
		            StudioModel model);

		void Delete(int id);

		POCOStudio Get(int id);

		List<POCOStudio> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7ff0029b8ccbf362a5e948152684a62d</Hash>
</Codenesium>*/