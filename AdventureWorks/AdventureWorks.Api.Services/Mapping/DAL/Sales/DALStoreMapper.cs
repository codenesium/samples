using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALStoreMapper: DALAbstractStoreMapper, IDALStoreMapper
        {
                public DALStoreMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>49097d9f7bad90151e83f1441c1e15dc</Hash>
</Codenesium>*/