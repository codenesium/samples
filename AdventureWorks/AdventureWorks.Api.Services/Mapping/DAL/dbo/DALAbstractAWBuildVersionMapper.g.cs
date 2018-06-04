using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALAWBuildVersionMapper
	{
		public virtual AWBuildVersion MapBOToEF(
			BOAWBuildVersion bo)
		{
			AWBuildVersion efAWBuildVersion = new AWBuildVersion ();

			efAWBuildVersion.SetProperties(
				bo.Database_Version,
				bo.ModifiedDate,
				bo.SystemInformationID,
				bo.VersionDate);
			return efAWBuildVersion;
		}

		public virtual BOAWBuildVersion MapEFToBO(
			AWBuildVersion ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOAWBuildVersion();

			bo.SetProperties(
				ef.SystemInformationID,
				ef.Database_Version,
				ef.ModifiedDate,
				ef.VersionDate);
			return bo;
		}

		public virtual List<BOAWBuildVersion> MapEFToBO(
			List<AWBuildVersion> records)
		{
			List<BOAWBuildVersion> response = new List<BOAWBuildVersion>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9a89adeb746f226e90b77f89dd5b6189</Hash>
</Codenesium>*/