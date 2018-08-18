using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALTransactionHistoryArchiveMapper : DALAbstractTransactionHistoryArchiveMapper, IDALTransactionHistoryArchiveMapper
	{
		public DALTransactionHistoryArchiveMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>58877873c1edb03441a74904c911f7c0</Hash>
</Codenesium>*/