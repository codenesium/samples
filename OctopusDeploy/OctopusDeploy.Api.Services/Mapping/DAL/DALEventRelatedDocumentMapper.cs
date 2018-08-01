using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALEventRelatedDocumentMapper : DALAbstractEventRelatedDocumentMapper, IDALEventRelatedDocumentMapper
	{
		public DALEventRelatedDocumentMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>695d8625fc6467df5898ec481055905e</Hash>
</Codenesium>*/