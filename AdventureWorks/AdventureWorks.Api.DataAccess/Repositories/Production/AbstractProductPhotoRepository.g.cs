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

		public AbstractProductPhotoRepository(ILogger logger,
		                                      ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(byte[] thumbNailPhoto,
		                          string thumbnailPhotoFileName,
		                          byte[] largePhoto,
		                          string largePhotoFileName,
		                          DateTime modifiedDate)
		{
			var record = new EFProductPhoto ();

			MapPOCOToEF(0, thumbNailPhoto,
			            thumbnailPhotoFileName,
			            largePhoto,
			            largePhotoFileName,
			            modifiedDate, record);

			this.context.Set<EFProductPhoto>().Add(record);
			this.context.SaveChanges();
			return record.ProductPhotoID;
		}

		public virtual void Update(int productPhotoID, byte[] thumbNailPhoto,
		                           string thumbnailPhotoFileName,
		                           byte[] largePhoto,
		                           string largePhotoFileName,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productPhotoID);
			}
			else
			{
				MapPOCOToEF(productPhotoID,  thumbNailPhoto,
				            thumbnailPhotoFileName,
				            largePhoto,
				            largePhotoFileName,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productPhotoID)
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

		public virtual void GetById(int productPhotoID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID,response);
		}

		protected virtual List<EFProductPhoto> SearchLinqEF(Expression<Func<EFProductPhoto, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductPhoto> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductPhotoes;
		}
		public virtual POCOProductPhoto GetByIdDirect(int productPhotoID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID,response);
			return response.ProductPhotoes.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFProductPhoto, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductPhoto> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductPhoto> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productPhotoID, byte[] thumbNailPhoto,
		                               string thumbnailPhotoFileName,
		                               byte[] largePhoto,
		                               string largePhotoFileName,
		                               DateTime modifiedDate, EFProductPhoto   efProductPhoto)
		{
			efProductPhoto.ProductPhotoID = productPhotoID;
			efProductPhoto.ThumbNailPhoto = thumbNailPhoto;
			efProductPhoto.ThumbnailPhotoFileName = thumbnailPhotoFileName;
			efProductPhoto.LargePhoto = largePhoto;
			efProductPhoto.LargePhotoFileName = largePhotoFileName;
			efProductPhoto.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductPhoto efProductPhoto,Response response)
		{
			if(efProductPhoto == null)
			{
				return;
			}
			response.AddProductPhoto(new POCOProductPhoto()
			{
				ProductPhotoID = efProductPhoto.ProductPhotoID.ToInt(),
				ThumbNailPhoto = efProductPhoto.ThumbNailPhoto,
				ThumbnailPhotoFileName = efProductPhoto.ThumbnailPhotoFileName,
				LargePhoto = efProductPhoto.LargePhoto,
				LargePhotoFileName = efProductPhoto.LargePhotoFileName,
				ModifiedDate = efProductPhoto.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>c043b30955c4778fc6f46e9118afd69c</Hash>
</Codenesium>*/