using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALTransactionHistoryArchiveMapper : DALAbstractTransactionHistoryArchiveMapper, IDALTransactionHistoryArchiveMapper
        {
                public DALTransactionHistoryArchiveMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3996ae29d9f7333bd35500e407b06051</Hash>
</Codenesium>*/