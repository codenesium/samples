using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class CustomerCommunicationRepository : AbstractCustomerCommunicationRepository, ICustomerCommunicationRepository
	{
		public CustomerCommunicationRepository(
			ILogger<CustomerCommunicationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0e8e3e388b8f8ad5ce86d76743e993c9</Hash>
</Codenesium>*/