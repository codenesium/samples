using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALPhoneNumberTypeMapper : DALAbstractPhoneNumberTypeMapper, IDALPhoneNumberTypeMapper
        {
                public DALPhoneNumberTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>aae76f86523eeafeb00bca2819a12dc9</Hash>
</Codenesium>*/