using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class DALAbstractPaymentTypeMapper
	{
		public virtual PaymentType MapBOToEF(
			BOPaymentType bo)
		{
			PaymentType efPaymentType = new PaymentType();
			efPaymentType.SetProperties(
				bo.Id,
				bo.Name);
			return efPaymentType;
		}

		public virtual BOPaymentType MapEFToBO(
			PaymentType ef)
		{
			var bo = new BOPaymentType();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOPaymentType> MapEFToBO(
			List<PaymentType> records)
		{
			List<BOPaymentType> response = new List<BOPaymentType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>439e1fb33c452e19d13b6084fd734612</Hash>
</Codenesium>*/