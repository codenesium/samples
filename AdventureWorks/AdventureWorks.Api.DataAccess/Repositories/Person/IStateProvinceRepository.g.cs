using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStateProvinceRepository
	{
		int Create(StateProvinceModel model);

		void Update(int stateProvinceID,
		            StateProvinceModel model);

		void Delete(int stateProvinceID);

		POCOStateProvince Get(int stateProvinceID);

		List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ed7435b00d872bfecd834dccac4e329e</Hash>
</Codenesium>*/