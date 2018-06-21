using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a2233b20b1f2ac679462e26af7fa7efa</Hash>
</Codenesium>*/