using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALPersonMapper: DALAbstractPersonMapper, IDALPersonMapper
        {
                public DALPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5d1ff658368153e2b41103298c203be2</Hash>
</Codenesium>*/