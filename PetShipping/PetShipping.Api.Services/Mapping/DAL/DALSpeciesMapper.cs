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
    <Hash>ffc400f3ce6dde395745b0465bdc3c39</Hash>
</Codenesium>*/