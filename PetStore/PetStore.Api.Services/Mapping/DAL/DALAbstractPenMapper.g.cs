using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public abstract class AbstractDALPenMapper
	{
		public virtual Pen MapBOToEF(
			BOPen bo)
		{
			Pen efPen = new Pen ();

			efPen.SetProperties(
				bo.Id,
				bo.Name);
			return efPen;
		}

		public virtual BOPen MapEFToBO(
			Pen ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPen();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOPen> MapEFToBO(
			List<Pen> records)
		{
			List<BOPen> response = new List<BOPen>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c1ee44ecac679781780ea89bbfb93eb3</Hash>
</Codenesium>*/