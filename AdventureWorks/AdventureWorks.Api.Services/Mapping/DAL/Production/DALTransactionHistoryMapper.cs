using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALTransactionHistoryMapper: DALAbstractTransactionHistoryMapper, IDALTransactionHistoryMapper
        {
                public DALTransactionHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8152467bc007b05e226ad9cc8986fbbe</Hash>
</Codenesium>*/