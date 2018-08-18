using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public abstract class DALAbstractFileTypeMapper
	{
		public virtual FileType MapBOToEF(
			BOFileType bo)
		{
			FileType efFileType = new FileType();
			efFileType.SetProperties(
				bo.Id,
				bo.Name);
			return efFileType;
		}

		public virtual BOFileType MapEFToBO(
			FileType ef)
		{
			var bo = new BOFileType();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOFileType> MapEFToBO(
			List<FileType> records)
		{
			List<BOFileType> response = new List<BOFileType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>907ba0228dd6d03058336e192a779702</Hash>
</Codenesium>*/