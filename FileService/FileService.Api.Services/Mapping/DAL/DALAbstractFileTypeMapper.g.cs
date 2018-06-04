using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services
{
	public abstract class AbstractDALFileTypeMapper
	{
		public virtual FileType MapBOToEF(
			BOFileType bo)
		{
			FileType efFileType = new FileType ();

			efFileType.SetProperties(
				bo.Id,
				bo.Name);
			return efFileType;
		}

		public virtual BOFileType MapEFToBO(
			FileType ef)
		{
			if (ef == null)
			{
				return null;
			}

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
    <Hash>d6e7c26c02f07686b354124834b59636</Hash>
</Codenesium>*/