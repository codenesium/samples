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
	public partial class CreditCardService : AbstractCreditCardService, ICreditCardService
	{
		public CreditCardService(
			ILogger<ICreditCardRepository> logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper bolcreditCardMapper,
			IDALCreditCardMapper dalcreditCardMapper,
			IBOLPersonCreditCardMapper bolPersonCreditCardMapper,
			IDALPersonCreditCardMapper dalPersonCreditCardMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
			)
			: base(logger,
			       creditCardRepository,
			       creditCardModelValidator,
			       bolcreditCardMapper,
			       dalcreditCardMapper,
			       bolPersonCreditCardMapper,
			       dalPersonCreditCardMapper,
			       bolSalesOrderHeaderMapper,
			       dalSalesOrderHeaderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5ebac22b127cd96d45eeebd6b764f3d5</Hash>
</Codenesium>*/