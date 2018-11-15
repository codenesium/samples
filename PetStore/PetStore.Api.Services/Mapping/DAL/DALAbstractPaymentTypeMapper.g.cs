using Microsoft.EntityFrameworkCore;
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
    <Hash>51f8aadcec15146d7d74127283f24103</Hash>
</Codenesium>*/