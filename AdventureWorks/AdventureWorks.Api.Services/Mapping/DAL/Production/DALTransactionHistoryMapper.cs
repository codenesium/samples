using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public class DALTransactionHistoryMapper: AbstractDALTransactionHistoryMapper, IDALTransactionHistoryMapper
	{
		public DALTransactionHistoryMapper()
		{}
	}
}

/*<Codenesium>
    <Hash>977f6c81ce447806735f2df35ba7f0d7</Hash>
</Codenesium>*/