using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPhoneNumberTypeMapper : DALAbstractPhoneNumberTypeMapper, IDALPhoneNumberTypeMapper
	{
		public DALPhoneNumberTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>013ff7bb1761f5bbbc3cfa6fa492b0a4</Hash>
</Codenesium>*/