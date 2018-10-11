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
	public partial class ContactTypeService : AbstractContactTypeService, IContactTypeService
	{
		public ContactTypeService(
			ILogger<IContactTypeRepository> logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper bolcontactTypeMapper,
			IDALContactTypeMapper dalcontactTypeMapper,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper)
			: base(logger,
			       contactTypeRepository,
			       contactTypeModelValidator,
			       bolcontactTypeMapper,
			       dalcontactTypeMapper,
			       bolBusinessEntityContactMapper,
			       dalBusinessEntityContactMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>34f5d7d9f24fdb3ecaef020b3a0d5ff3</Hash>
</Codenesium>*/