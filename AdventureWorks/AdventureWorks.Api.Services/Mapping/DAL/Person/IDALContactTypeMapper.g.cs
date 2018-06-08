using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALContactTypeMapper
        {
                ContactType MapBOToEF(
                        BOContactType bo);

                BOContactType MapEFToBO(
                        ContactType efContactType);

                List<BOContactType> MapEFToBO(
                        List<ContactType> records);
        }
}

/*<Codenesium>
    <Hash>877e7ed047ea602a83ec730c33117418</Hash>
</Codenesium>*/