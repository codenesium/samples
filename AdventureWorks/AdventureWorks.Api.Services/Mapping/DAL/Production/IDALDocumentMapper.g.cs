using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALDocumentMapper
        {
                Document MapBOToEF(
                        BODocument bo);

                BODocument MapEFToBO(
                        Document efDocument);

                List<BODocument> MapEFToBO(
                        List<Document> records);
        }
}

/*<Codenesium>
    <Hash>50fbf31670cffdf5c3944494c94af8c7</Hash>
</Codenesium>*/