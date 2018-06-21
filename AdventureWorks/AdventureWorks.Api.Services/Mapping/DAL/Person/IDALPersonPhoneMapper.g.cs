using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALPersonPhoneMapper
        {
                PersonPhone MapBOToEF(
                        BOPersonPhone bo);

                BOPersonPhone MapEFToBO(
                        PersonPhone efPersonPhone);

                List<BOPersonPhone> MapEFToBO(
                        List<PersonPhone> records);
        }
}

/*<Codenesium>
    <Hash>ecf820658a787f854146f08620b2863a</Hash>
</Codenesium>*/