using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IIllustrationRepository
	{
		Task<POCOIllustration> Create(ApiIllustrationModel model);

		Task Update(int illustrationID,
		            ApiIllustrationModel model);

		Task Delete(int illustrationID);

		Task<POCOIllustration> Get(int illustrationID);

		Task<List<POCOIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>954f25e5f4435b942a733a7eec1a94dd</Hash>
</Codenesium>*/