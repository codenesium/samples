using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		POCOErrorLog Create(ApiErrorLogModel model);

		void Update(int errorLogID,
		            ApiErrorLogModel model);

		void Delete(int errorLogID);

		POCOErrorLog Get(int errorLogID);

		List<POCOErrorLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5f134cd254dd5edd803de3d16eb286ab</Hash>
</Codenesium>*/