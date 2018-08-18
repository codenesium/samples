using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALTransactionHistoryMapper : DALAbstractTransactionHistoryMapper, IDALTransactionHistoryMapper
	{
		public DALTransactionHistoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>b16b3dcce41833f7441e09ba334593aa</Hash>
</Codenesium>*/