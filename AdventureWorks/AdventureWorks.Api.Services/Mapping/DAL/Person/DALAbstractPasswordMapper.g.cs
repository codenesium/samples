using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractPasswordMapper
	{
		public virtual Password MapBOToEF(
			BOPassword bo)
		{
			Password efPassword = new Password();
			efPassword.SetProperties(
				bo.BusinessEntityID,
				bo.ModifiedDate,
				bo.PasswordHash,
				bo.PasswordSalt,
				bo.Rowguid);
			return efPassword;
		}

		public virtual BOPassword MapEFToBO(
			Password ef)
		{
			var bo = new BOPassword();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.PasswordHash,
				ef.PasswordSalt,
				ef.Rowguid);
			return bo;
		}

		public virtual List<BOPassword> MapEFToBO(
			List<Password> records)
		{
			List<BOPassword> response = new List<BOPassword>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>59c3bc491e92fb728ff5c6c4b02a227e</Hash>
</Codenesium>*/