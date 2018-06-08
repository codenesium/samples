using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductReviewMapper: DALAbstractProductReviewMapper, IDALProductReviewMapper
        {
                public DALProductReviewMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>dbbaa57a20e04295d7c2937e3e27d9a6</Hash>
</Codenesium>*/