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
    <Hash>487eeaad5eb19e82268d9fe7610e962c</Hash>
</Codenesium>*/