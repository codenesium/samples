using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public interface IDALPenMapper
        {
                Pen MapBOToEF(
                        BOPen bo);

                BOPen MapEFToBO(
                        Pen efPen);

                List<BOPen> MapEFToBO(
                        List<Pen> records);
        }
}

/*<Codenesium>
    <Hash>b6add7ec36586373a1386088f5f56c29</Hash>
</Codenesium>*/