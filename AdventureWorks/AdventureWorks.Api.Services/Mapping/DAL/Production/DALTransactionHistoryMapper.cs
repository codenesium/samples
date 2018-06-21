using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALTransactionHistoryMapper : DALAbstractTransactionHistoryMapper, IDALTransactionHistoryMapper
        {
                public DALTransactionHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f573d7ac62db82d1ae77b20c536aac0c</Hash>
</Codenesium>*/