using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		POCOClasp Create(ClaspModel model);

		void Update(int id,
		            ClaspModel model);

		void Delete(int id);

		POCOClasp Get(int id);

		List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fc6a6797d99249f1aa655441d56fda53</Hash>
</Codenesium>*/