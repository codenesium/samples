using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALSpeciesMapper : DALAbstractSpeciesMapper, IDALSpeciesMapper
	{
		public DALSpeciesMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>03611be8cbb4dec62beef88b4ffb41ea</Hash>
</Codenesium>*/