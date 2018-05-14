using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		POCOClasp Create(ApiClaspModel model);

		void Update(int id,
		            ApiClaspModel model);

		void Delete(int id);

		POCOClasp Get(int id);

		List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>33811913bf6f97d941e70f361eb98f73</Hash>
</Codenesium>*/