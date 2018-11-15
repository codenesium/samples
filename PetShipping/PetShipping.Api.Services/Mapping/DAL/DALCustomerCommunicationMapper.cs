using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALCustomerCommunicationMapper : DALAbstractCustomerCommunicationMapper, IDALCustomerCommunicationMapper
	{
		public DALCustomerCommunicationMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2ec7759353062edc47da97df70939646</Hash>
</Codenesium>*/