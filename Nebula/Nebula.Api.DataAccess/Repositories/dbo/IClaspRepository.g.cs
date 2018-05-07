using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		int Create(ClaspModel model);

		void Update(int id,
		            ClaspModel model);

		void Delete(int id);

		POCOClasp Get(int id);

		List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>28a40ba50d42c2a7fdbfea5311db7fbc</Hash>
</Codenesium>*/