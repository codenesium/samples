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
    <Hash>4be17c3efea833e734b585d3ca4f6c33</Hash>
</Codenesium>*/