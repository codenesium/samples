using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IIllustrationRepository
	{
		Task<DTOIllustration> Create(DTOIllustration dto);

		Task Update(int illustrationID,
		            DTOIllustration dto);

		Task Delete(int illustrationID);

		Task<DTOIllustration> Get(int illustrationID);

		Task<List<DTOIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>837b8d699ebc07d8ba5785f0f2601037</Hash>
</Codenesium>*/