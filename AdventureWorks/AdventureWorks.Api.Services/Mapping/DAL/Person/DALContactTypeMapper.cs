using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALContactTypeMapper: DALAbstractContactTypeMapper, IDALContactTypeMapper
        {
                public DALContactTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>77b55b2cec51ce87e052572973d0de77</Hash>
</Codenesium>*/