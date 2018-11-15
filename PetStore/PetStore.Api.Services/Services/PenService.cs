using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class PenService : AbstractPenService, IPenService
	{
		public PenService(
			ILogger<IPenRepository> logger,
			IPenRepository penRepository,
			IApiPenServerRequestModelValidator penModelValidator,
			IBOLPenMapper bolPenMapper,
			IDALPenMapper dalPenMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       penRepository,
			       penModelValidator,
			       bolPenMapper,
			       dalPenMapper,
			       bolPetMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ee4830a7fdc6381e9cc261afdcc1d0bb</Hash>
</Codenesium>*/