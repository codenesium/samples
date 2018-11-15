using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class DALAbstractPenMapper
	{
		public virtual Pen MapBOToEF(
			BOPen bo)
		{
			Pen efPen = new Pen();
			efPen.SetProperties(
				bo.Id,
				bo.Name);
			return efPen;
		}

		public virtual BOPen MapEFToBO(
			Pen ef)
		{
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
    <Hash>db0cac92c5636cdbc8fe9d670c746024</Hash>
</Codenesium>*/