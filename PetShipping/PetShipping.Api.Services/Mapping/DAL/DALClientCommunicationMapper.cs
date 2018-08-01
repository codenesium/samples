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
    <Hash>6a991791fca1a791434133ad36aaa16e</Hash>
</Codenesium>*/