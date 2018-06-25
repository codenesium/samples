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
    <Hash>66e47ebcbda3821eb5996e2607145946</Hash>
</Codenesium>*/