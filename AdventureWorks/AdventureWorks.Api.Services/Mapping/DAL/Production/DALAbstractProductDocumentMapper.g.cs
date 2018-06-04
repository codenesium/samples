using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALProductDocumentMapper
	{
		public virtual ProductDocument MapBOToEF(
			BOProductDocument bo)
		{
			ProductDocument efProductDocument = new ProductDocument ();

			efProductDocument.SetProperties(
				bo.DocumentNode,
				bo.ModifiedDate,
				bo.ProductID);
			return efProductDocument;
		}

		public virtual BOProductDocument MapEFToBO(
			ProductDocument ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOProductDocument();

			bo.SetProperties(
				ef.ProductID,
				ef.DocumentNode,
				ef.ModifiedDate);
			return bo;
		}

		public virtual List<BOProductDocument> MapEFToBO(
			List<ProductDocument> records)
		{
			List<BOProductDocument> response = new List<BOProductDocument>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7c04408fd4b96505bf48b893b432ed6d</Hash>
</Codenesium>*/