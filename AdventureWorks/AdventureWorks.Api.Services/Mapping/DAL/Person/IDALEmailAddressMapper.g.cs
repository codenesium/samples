using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALEmailAddressMapper
        {
                EmailAddress MapBOToEF(
                        BOEmailAddress bo);

                BOEmailAddress MapEFToBO(
                        EmailAddress efEmailAddress);

                List<BOEmailAddress> MapEFToBO(
                        List<EmailAddress> records);
        }
}

/*<Codenesium>
    <Hash>b3721d9f8648d7be47daa39110f3ee9f</Hash>
</Codenesium>*/