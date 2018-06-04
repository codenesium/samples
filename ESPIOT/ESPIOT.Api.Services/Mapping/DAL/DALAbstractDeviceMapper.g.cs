using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractDALDeviceMapper
	{
		public virtual Device MapBOToEF(
			BODevice bo)
		{
			Device efDevice = new Device ();

			efDevice.SetProperties(
				bo.Id,
				bo.Name,
				bo.PublicId);
			return efDevice;
		}

		public virtual BODevice MapEFToBO(
			Device ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BODevice();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.PublicId);
			return bo;
		}

		public virtual List<BODevice> MapEFToBO(
			List<Device> records)
		{
			List<BODevice> response = new List<BODevice>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>66675256f252e720abc4b8b80c0e021a</Hash>
</Codenesium>*/