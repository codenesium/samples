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
	public abstract class AbstractSpecialOfferProductRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSpecialOfferProductRepository(ILogger logger,
		                                             ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int productID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSpecialOfferProduct ();

			MapPOCOToEF(0, productID,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSpecialOfferProduct>().Add(record);
			this._context.SaveChanges();
			return record.specialOfferID;
		}

		public virtual void Update(int specialOfferID, int productID,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.specialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",specialOfferID);
			}
			else
			{
				MapPOCOToEF(specialOfferID,  productID,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int specialOfferID)
		{
			var record = this.SearchLinqEF(x => x.specialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSpecialOfferProduct>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int specialOfferID, Response response)
		{
			this.SearchLinqPOCO(x => x.specialOfferID == specialOfferID,response);
		}

		protected virtual List<EFSpecialOfferProduct> SearchLinqEF(Expression<Func<EFSpecialOfferProduct, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpecialOfferProduct> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSpecialOfferProduct, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSpecialOfferProduct> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSpecialOfferProduct> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int specialOfferID, int productID,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSpecialOfferProduct   efSpecialOfferProduct)
		{
			efSpecialOfferProduct.specialOfferID = specialOfferID;
			efSpecialOfferProduct.productID = productID;
			efSpecialOfferProduct.rowguid = rowguid;
			efSpecialOfferProduct.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSpecialOfferProduct efSpecialOfferProduct,Response response)
		{
			if(efSpecialOfferProduct == null)
			{
				return;
			}
			response.AddSpecialOfferProduct(new POCOSpecialOfferProduct()
			{
				SpecialOfferID = efSpecialOfferProduct.specialOfferID.ToInt(),
				ProductID = efSpecialOfferProduct.productID.ToInt(),
				Rowguid = efSpecialOfferProduct.rowguid,
				ModifiedDate = efSpecialOfferProduct.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>c61d0e88b7b26a9749cab14f23cb0dbd</Hash>
</Codenesium>*/