using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALPaymentTypeMapper
	{
		PaymentType MapBOToEF(
			BOPaymentType bo);

		BOPaymentType MapEFToBO(
			PaymentType efPaymentType);

		List<BOPaymentType> MapEFToBO(
			List<PaymentType> records);
	}
}

/*<Codenesium>
    <Hash>00bf0ff546edf95e6275ea6dd33946e0</Hash>
</Codenesium>*/