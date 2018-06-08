using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALPhoneNumberTypeMapper: DALAbstractPhoneNumberTypeMapper, IDALPhoneNumberTypeMapper
        {
                public DALPhoneNumberTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>53ccb17c56172fed3a8370bca82a56b6</Hash>
</Codenesium>*/