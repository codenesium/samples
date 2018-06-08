using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALTransactionHistoryArchiveMapper: DALAbstractTransactionHistoryArchiveMapper, IDALTransactionHistoryArchiveMapper
        {
                public DALTransactionHistoryArchiveMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>dfec698718f2db75fab26fd5adbd070f</Hash>
</Codenesium>*/