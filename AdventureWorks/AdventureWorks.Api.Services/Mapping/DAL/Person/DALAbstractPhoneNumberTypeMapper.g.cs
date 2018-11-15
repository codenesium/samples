using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractPhoneNumberTypeMapper
	{
		public virtual PhoneNumberType MapBOToEF(
			BOPhoneNumberType bo)
		{
			PhoneNumberType efPhoneNumberType = new PhoneNumberType();
			efPhoneNumberType.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.PhoneNumberTypeID);
			return efPhoneNumberType;
		}

		public virtual BOPhoneNumberType MapEFToBO(
			PhoneNumberType ef)
		{
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
    <Hash>770d94cf78f060d65e8f28ff177a84a9</Hash>
</Codenesium>*/