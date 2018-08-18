using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALClientCommunicationMapper : DALAbstractClientCommunicationMapper, IDALClientCommunicationMapper
	{
		public DALClientCommunicationMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8c79d0c6d6f89c7b7812dc158289f58e</Hash>
</Codenesium>*/