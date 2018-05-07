using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		int Create(AWBuildVersionModel model);

		void Update(int systemInformationID,
		            AWBuildVersionModel model);

		void Delete(int systemInformationID);

		POCOAWBuildVersion Get(int systemInformationID);

		List<POCOAWBuildVersion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c181dfe34b94f117f3e743ecfa3f1507</Hash>
</Codenesium>*/