using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALPersonPhoneMapper : DALAbstractPersonPhoneMapper, IDALPersonPhoneMapper
        {
                public DALPersonPhoneMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>130b6780aa169afe120ae17106733ca0</Hash>
</Codenesium>*/