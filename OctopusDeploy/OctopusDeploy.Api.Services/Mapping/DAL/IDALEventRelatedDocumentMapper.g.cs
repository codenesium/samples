using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALEventRelatedDocumentMapper
        {
                EventRelatedDocument MapBOToEF(
                        BOEventRelatedDocument bo);

                BOEventRelatedDocument MapEFToBO(
                        EventRelatedDocument efEventRelatedDocument);

                List<BOEventRelatedDocument> MapEFToBO(
                        List<EventRelatedDocument> records);
        }
}

/*<Codenesium>
    <Hash>c58ebaf96b308c76ad297790a1703dc6</Hash>
</Codenesium>*/