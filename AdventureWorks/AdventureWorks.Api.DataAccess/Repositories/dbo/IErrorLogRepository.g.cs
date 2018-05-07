using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IErrorLogRepository
	{
		int Create(ErrorLogModel model);

		void Update(int errorLogID,
		            ErrorLogModel model);

		void Delete(int errorLogID);

		POCOErrorLog Get(int errorLogID);

		List<POCOErrorLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4ce36137a2e726842fc6e26eee4ed18e</Hash>
</Codenesium>*/