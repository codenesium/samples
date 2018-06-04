using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPhoneNumberTypeMapper
	{
		public virtual PhoneNumberType MapBOToEF(
			BOPhoneNumberType bo)
		{
			PhoneNumberType efPhoneNumberType = new PhoneNumberType ();

			efPhoneNumberType.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.PhoneNumberTypeID);
			return efPhoneNumberType;
		}

		public virtual BOPhoneNumberType MapEFToBO(
			PhoneNumberType ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPhoneNumberType();

			bo.SetProperties(
				ef.PhoneNumberTypeID,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOPhoneNumberType> MapEFToBO(
			List<PhoneNumberType> records)
		{
			List<BOPhoneNumberType> response = new List<BOPhoneNumberType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1d0ee5638ff7e6d5ee9c0324b8f49815</Hash>
</Codenesium>*/