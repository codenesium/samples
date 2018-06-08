using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class DALSpeciesMapper: DALAbstractSpeciesMapper, IDALSpeciesMapper
        {
                public DALSpeciesMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7dfbd3d61c643397b47f086349399a1e</Hash>
</Codenesium>*/