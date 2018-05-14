using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		POCOAWBuildVersion Create(ApiAWBuildVersionModel model);

		void Update(int systemInformationID,
		            ApiAWBuildVersionModel model);

		void Delete(int systemInformationID);

		POCOAWBuildVersion Get(int systemInformationID);

		List<POCOAWBuildVersion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d9ca66101cfd1d61dd5478c41e1f7207</Hash>
</Codenesium>*/