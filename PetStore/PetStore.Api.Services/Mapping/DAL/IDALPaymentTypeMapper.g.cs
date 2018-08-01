using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public interface IDALPaymentTypeMapper
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
    <Hash>a3b5e31583f4e35da5b2d421c7b00003</Hash>
</Codenesium>*/