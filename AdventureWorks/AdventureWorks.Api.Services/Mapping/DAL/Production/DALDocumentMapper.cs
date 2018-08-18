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
    <Hash>2a2828c463b10a8f49ab156060927cc7</Hash>
</Codenesium>*/