using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PersonPhoneRepository: AbstractPersonPhoneRepository, IPersonPhoneRepository
	{
		public PersonPhoneRepository(
			ILogger<PersonPhoneRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>901a00af79221c6b0a899df611dbb163</Hash>
</Codenesium>*/