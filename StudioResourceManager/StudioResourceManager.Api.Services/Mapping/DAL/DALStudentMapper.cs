using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class DALStudentMapper : DALAbstractStudentMapper, IDALStudentMapper
	{
		public DALStudentMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>60565a14cc3af8223cbca818c595d584</Hash>
</Codenesium>*/