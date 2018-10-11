using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class PersonPhoneService : AbstractPersonPhoneService, IPersonPhoneService
	{
		public PersonPhoneService(
			ILogger<IPersonPhoneRepository> logger,
			IPersonPhoneRepository personPhoneRepository,
			IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
			IBOLPersonPhoneMapper bolpersonPhoneMapper,
			IDALPersonPhoneMapper dalpersonPhoneMapper)
			: base(logger,
			       personPhoneRepository,
			       personPhoneModelValidator,
			       bolpersonPhoneMapper,
			       dalpersonPhoneMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>12d6054217a7124a1f5c33fa95f514c0</Hash>
</Codenesium>*/