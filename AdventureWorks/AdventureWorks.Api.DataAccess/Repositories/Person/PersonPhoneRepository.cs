using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PersonPhoneRepository: AbstractPersonPhoneRepository, IPersonPhoneRepository
	{
		public PersonPhoneRepository(
			IDALPersonPhoneMapper mapper,
			ILogger<PersonPhoneRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4f9ee4fa26cf438ba2484e5abde4d0b8</Hash>
</Codenesium>*/