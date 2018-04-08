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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductProductPhotoRepository(ILogger logger,
		                                             ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int productPhotoID,
		                          bool primary,
		                          DateTime modifiedDate)
		{
			var record = new EFProductProductPhoto ();

			MapPOCOToEF(0, productPhotoID,
			            primary,
			            modifiedDate, record);

			this.context.Set<EFProductProductPhoto>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(int productID, int productPhotoID,
		                           bool primary,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  productPhotoID,
				            primary,
				            modifiedDate, record);
				this.context.SaveChanges();
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
				this.context.Set<EFProductProductPhoto>().Remove(record);
				this.context.SaveChanges();
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

		public virtual List<POCOProductProductPhoto > GetWhereDirect(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductProductPhotoes;
		}
		public virtual POCOProductProductPhoto GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID,response);
			return response.ProductProductPhotoes.FirstOrDefault();
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

			ProductRepository.MapEFToPOCO(efProductProductPhoto.Product, response);

			ProductPhotoRepository.MapEFToPOCO(efProductProductPhoto.ProductPhoto, response);
		}
	}
}

/*<Codenesium>
    <Hash>f05261e37cc3d68e8d60ed5414e985fb</Hash>
</Codenesium>*/