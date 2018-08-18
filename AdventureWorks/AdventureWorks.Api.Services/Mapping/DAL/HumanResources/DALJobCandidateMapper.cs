using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALJobCandidateMapper : DALAbstractJobCandidateMapper, IDALJobCandidateMapper
	{
		public DALJobCandidateMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e06064221a232bc28a7255c3bc2b976a</Hash>
</Codenesium>*/