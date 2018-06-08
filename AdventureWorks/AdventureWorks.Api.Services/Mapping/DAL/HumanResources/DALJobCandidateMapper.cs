using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALJobCandidateMapper: DALAbstractJobCandidateMapper, IDALJobCandidateMapper
        {
                public DALJobCandidateMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7df7e667d4546b23aac4ff7dd6317065</Hash>
</Codenesium>*/