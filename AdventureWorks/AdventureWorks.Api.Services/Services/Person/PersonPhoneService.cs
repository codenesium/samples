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
			IDALPersonPhoneMapper dalpersonPhoneMapper
			)
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
    <Hash>dedcf1793169636c3b2a924df9e11ce1</Hash>
</Codenesium>*/