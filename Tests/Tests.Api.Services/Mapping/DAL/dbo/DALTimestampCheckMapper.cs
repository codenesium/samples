using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public partial class DALTimestampCheckMapper : DALAbstractTimestampCheckMapper, IDALTimestampCheckMapper
        {
                public DALTimestampCheckMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>08f56f0a116be70fa233794b04d9a371</Hash>
</Codenesium>*/