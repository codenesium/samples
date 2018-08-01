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
    <Hash>4390f5fa39b72d4a09912a59abc5509a</Hash>
</Codenesium>*/