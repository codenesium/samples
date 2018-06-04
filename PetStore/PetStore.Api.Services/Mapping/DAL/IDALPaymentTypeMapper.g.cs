using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
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
    <Hash>8c259dd7f9253264f2323bc63b22de84</Hash>
</Codenesium>*/