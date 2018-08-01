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
    <Hash>4a02a780830b0bbf540582548921ae02</Hash>
</Codenesium>*/