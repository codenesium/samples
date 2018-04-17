using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOContactType: AbstractBOContactType, IBOContactType
	{
		public BOContactType(
			ILogger<ContactTypeRepository> logger,
			IContactTypeRepository contactTypeRepository,
			IContactTypeModelValidator contactTypeModelValidator)
			: base(logger, contactTypeRepository, contactTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d1eea692b9302037044e01405bb5fe0c</Hash>
</Codenesium>*/