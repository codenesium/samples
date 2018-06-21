using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>0b8f81a358db233a3b05b88a2286ee56</Hash>
</Codenesium>*/