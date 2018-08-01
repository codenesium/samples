using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALDocumentMapper : DALAbstractDocumentMapper, IDALDocumentMapper
	{
		public DALDocumentMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e5f930a159300d2c19ba2cd360af62f7</Hash>
</Codenesium>*/