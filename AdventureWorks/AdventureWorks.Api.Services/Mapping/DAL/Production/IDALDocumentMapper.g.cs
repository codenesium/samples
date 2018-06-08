using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>c74c8b5d030498e6bdd7d6bb0974a046</Hash>
</Codenesium>*/