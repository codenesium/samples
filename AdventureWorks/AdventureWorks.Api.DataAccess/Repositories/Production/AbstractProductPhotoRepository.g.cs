using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductPhotoRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductPhotoRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate)
		{
			var record = new EFProductPhoto();

			MapPOCOToEF(
				0,
				thumbNailPhoto,
				thumbnailPhotoFileName,
				largePhoto,
				largePhotoFileName,
				modifiedDate,
				record);

			this.context.Set<EFProductPhoto>().Add(record);
			this.context.SaveChanges();
			return record.ProductPhotoID;
		}

		public virtual void Update(
			int productPhotoID,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productPhotoID}");
			}
			else
			{
				MapPOCOToEF(
					productPhotoID,
					thumbNailPhoto,
					thumbnailPhotoFileName,
					largePhoto,
					largePhotoFileName,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productPhotoID)
		{
			var record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductPhoto>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int productPhotoID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID, response);
			return response;
		}

		public virtual POCOProductPhoto GetByIdDirect(int productPhotoID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID, response);
			return response.ProductPhotoes.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductPhotoes;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductPhoto, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductPhoto> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductPhoto> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFProductPhoto> SearchLinqEF(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int productPhotoID,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			EFProductPhoto efProductPhoto)
		{
			efProductPhoto.SetProperties(productPhotoID.ToInt(), thumbNailPhoto, thumbnailPhotoFileName, largePhoto, largePhotoFileName, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFProductPhoto efProductPhoto,
			Response response)
		{
			if (efProductPhoto == null)
			{
				return;
			}

			response.AddProductPhoto(new POCOProductPhoto(efProductPhoto.ProductPhotoID.ToInt(), efProductPhoto.ThumbNailPhoto, efProductPhoto.ThumbnailPhotoFileName, efProductPhoto.LargePhoto, efProductPhoto.LargePhotoFileName, efProductPhoto.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>591f389d53e5258bfa47b9816c5d3048</Hash>
</Codenesium>*/