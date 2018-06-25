using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALProductModelMapper : DALAbstractProductModelMapper, IDALProductModelMapper
        {
                public DALProductModelMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d6a3c7d2a70bcc849cc4400b75eb4729</Hash>
</Codenesium>*/