using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>3689cc4ded5a4ef738166515e6314ae8</Hash>
</Codenesium>*/