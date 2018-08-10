using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PhoneNumberTypeRepository : AbstractPhoneNumberTypeRepository, IPhoneNumberTypeRepository
	{
		public PhoneNumberTypeRepository(
			ILogger<PhoneNumberTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>479894cf4030ce9295625f323e268715</Hash>
</Codenesium>*/