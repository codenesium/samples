using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class VPersonService : AbstractVPersonService, IVPersonService
	{
		public VPersonService(
			ILogger<IVPersonRepository> logger,
			IVPersonRepository vPersonRepository,
			IApiVPersonServerRequestModelValidator vPersonModelValidator,
			IBOLVPersonMapper bolVPersonMapper,
			IDALVPersonMapper dalVPersonMapper)
			: base(logger,
			       vPersonRepository,
			       vPersonModelValidator,
			       bolVPersonMapper,
			       dalVPersonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>10cd241a876a3184fcde7dd4072f6e09</Hash>
</Codenesium>*/