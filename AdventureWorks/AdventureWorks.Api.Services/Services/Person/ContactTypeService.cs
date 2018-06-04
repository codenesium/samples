using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ContactTypeService: AbstractContactTypeService, IContactTypeService
	{
		public ContactTypeService(
			ILogger<ContactTypeRepository> logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper BOLcontactTypeMapper,
			IDALContactTypeMapper DALcontactTypeMapper)
			: base(logger, contactTypeRepository,
			       contactTypeModelValidator,
			       BOLcontactTypeMapper,
			       DALcontactTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>d2ceccb470d184e69af17c558693fd39</Hash>
</Codenesium>*/