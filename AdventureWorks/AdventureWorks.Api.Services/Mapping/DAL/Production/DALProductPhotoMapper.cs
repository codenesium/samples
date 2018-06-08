using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductPhotoMapper: DALAbstractProductPhotoMapper, IDALProductPhotoMapper
        {
                public DALProductPhotoMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a754e4369b403560757a97297cd7d916</Hash>
</Codenesium>*/