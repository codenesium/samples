using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PhoneNumberTypeRepository: AbstractPhoneNumberTypeRepository, IPhoneNumberTypeRepository
	{
		public PhoneNumberTypeRepository(
			ILogger<PhoneNumberTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e02c3a77ece9f45538e9e8b48411dccf</Hash>
</Codenesium>*/