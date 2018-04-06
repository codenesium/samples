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
	public abstract class AbstractProductProductPhotoRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductProductPhotoRepository(ILogger logger,
		                                             ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int productPhotoID,
		                          bool primary,
		                          DateTime modifiedDate)
		{
			var record = new EFProductProductPhoto ();

			MapPOCOToEF(0, productPhotoID,
			            primary,
			            modifiedDate, record);

			this._context.Set<EFProductProductPhoto>().Add(record);
			this._context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(int productID, int productPhotoID,
		                           bool primary,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  productPhotoID,
				            primary,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productID)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductProductPhoto>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductID == productID,response);
		}

		protected virtual List<EFProductProductPhoto> SearchLinqEF(Expression<Func<EFProductProductPhoto, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductProductPhoto> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductProductPhoto, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductProductPhoto, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductProductPhoto> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductProductPhoto> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productID, int productPhotoID,
		                               bool primary,
		                               DateTime modifiedDate, EFProductProductPhoto   efProductProductPhoto)
		{
			efProductProductPhoto.ProductID = productID;
			efProductProductPhoto.ProductPhotoID = productPhotoID;
			efProductProductPhoto.Primary = primary;
			efProductProductPhoto.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductProductPhoto efProductProductPhoto,Response response)
		{
			if(efProductProductPhoto == null)
			{
				return;
			}
			response.AddProductProductPhoto(new POCOProductProductPhoto()
			{
				Primary = efProductProductPhoto.Primary,
				ModifiedDate = efProductProductPhoto.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efProductProductPhoto.ProductID,
				                                     "Products"),
				ProductPhotoID = new ReferenceEntity<int>(efProductProductPhoto.ProductPhotoID,
				                                          "ProductPhotoes"),
			});

			ProductRepository.MapEFToPOCO(efProductProductPhoto.ProductRef, response);

			ProductPhotoRepository.MapEFToPOCO(efProductProductPhoto.ProductPhotoRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>d62a734ae1326baf84c2c809b3f750c5</Hash>
</Codenesium>*/