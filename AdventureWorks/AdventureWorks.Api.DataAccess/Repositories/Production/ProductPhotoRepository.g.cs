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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductPhotoRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFProductPhoto>().Add(record);
			this._context.SaveChanges();
			return record.productPhotoID;
		}

		public virtual void Update(int productPhotoID, byte[] thumbNailPhoto,
		                           string thumbnailPhotoFileName,
		                           byte[] largePhoto,
		                           string largePhotoFileName,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productPhotoID == productPhotoID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productPhotoID);
			}
			else
			{
				MapPOCOToEF(productPhotoID,  thumbNailPhoto,
				            thumbnailPhotoFileName,
				            largePhoto,
				            largePhotoFileName,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productPhotoID)
		{
			var record = this.SearchLinqEF(x => x.productPhotoID == productPhotoID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductPhoto>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productPhotoID, Response response)
		{
			this.SearchLinqPOCO(x => x.productPhotoID == productPhotoID,response);
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
			efProductPhoto.productPhotoID = productPhotoID;
			efProductPhoto.thumbNailPhoto = thumbNailPhoto;
			efProductPhoto.thumbnailPhotoFileName = thumbnailPhotoFileName;
			efProductPhoto.largePhoto = largePhoto;
			efProductPhoto.largePhotoFileName = largePhotoFileName;
			efProductPhoto.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductPhoto efProductPhoto,Response response)
		{
			if(efProductPhoto == null)
			{
				return;
			}
			response.AddProductPhoto(new POCOProductPhoto()
			{
				ProductPhotoID = efProductPhoto.productPhotoID.ToInt(),
				ThumbNailPhoto = efProductPhoto.thumbNailPhoto,
				ThumbnailPhotoFileName = efProductPhoto.thumbnailPhotoFileName,
				LargePhoto = efProductPhoto.largePhoto,
				LargePhotoFileName = efProductPhoto.largePhotoFileName,
				ModifiedDate = efProductPhoto.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>70a59f72060820580a7a9974cdbafb2c</Hash>
</Codenesium>*/