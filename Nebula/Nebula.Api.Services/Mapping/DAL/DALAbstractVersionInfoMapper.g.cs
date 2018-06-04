using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALVersionInfoMapper
	{
		public virtual VersionInfo MapBOToEF(
			BOVersionInfo bo)
		{
			VersionInfo efVersionInfo = new VersionInfo ();

			efVersionInfo.SetProperties(
				bo.AppliedOn,
				bo.Description,
				bo.Version);
			return efVersionInfo;
		}

		public virtual BOVersionInfo MapEFToBO(
			VersionInfo ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOVersionInfo();

			bo.SetProperties(
				ef.Version,
				ef.AppliedOn,
				ef.Description);
			return bo;
		}

		public virtual List<BOVersionInfo> MapEFToBO(
			List<VersionInfo> records)
		{
			List<BOVersionInfo> response = new List<BOVersionInfo>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>59ac3395e6ebd852362e8af4ae5875f8</Hash>
</Codenesium>*/