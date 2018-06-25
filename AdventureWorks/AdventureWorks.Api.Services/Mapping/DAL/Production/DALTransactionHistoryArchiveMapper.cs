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
    <Hash>36d3d84524d92cf13fede86ba7642770</Hash>
</Codenesium>*/