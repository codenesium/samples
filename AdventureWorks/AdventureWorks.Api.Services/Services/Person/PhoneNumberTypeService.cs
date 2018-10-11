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
	public partial class PhoneNumberTypeService : AbstractPhoneNumberTypeService, IPhoneNumberTypeService
	{
		public PhoneNumberTypeService(
			ILogger<IPhoneNumberTypeRepository> logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeRequestModelValidator phoneNumberTypeModelValidator,
			IBOLPhoneNumberTypeMapper bolphoneNumberTypeMapper,
			IDALPhoneNumberTypeMapper dalphoneNumberTypeMapper,
			IBOLPersonPhoneMapper bolPersonPhoneMapper,
			IDALPersonPhoneMapper dalPersonPhoneMapper)
			: base(logger,
			       phoneNumberTypeRepository,
			       phoneNumberTypeModelValidator,
			       bolphoneNumberTypeMapper,
			       dalphoneNumberTypeMapper,
			       bolPersonPhoneMapper,
			       dalPersonPhoneMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9ad1709f314b10bac6e1dcc2c8c5dffe</Hash>
</Codenesium>*/