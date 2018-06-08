using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>5fff4d075b3f9016eb254fe541d1483d</Hash>
</Codenesium>*/