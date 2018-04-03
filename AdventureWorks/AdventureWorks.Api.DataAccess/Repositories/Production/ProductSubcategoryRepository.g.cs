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
	public abstract class AbstractProductSubcategoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductSubcategoryRepository(ILogger logger,
		                                            ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int productCategoryID,
		                          string name,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductSubcategory ();

			MapPOCOToEF(0, productCategoryID,
			            name,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFProductSubcategory>().Add(record);
			this._context.SaveChanges();
			return record.productSubcategoryID;
		}

		public virtual void Update(int productSubcategoryID, int productCategoryID,
		                           string name,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productSubcategoryID == productSubcategoryID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productSubcategoryID);
			}
			else
			{
				MapPOCOToEF(productSubcategoryID,  productCategoryID,
				            name,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productSubcategoryID)
		{
			var record = this.SearchLinqEF(x => x.productSubcategoryID == productSubcategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductSubcategory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productSubcategoryID, Response response)
		{
			this.SearchLinqPOCO(x => x.productSubcategoryID == productSubcategoryID,response);
		}

		protected virtual List<EFProductSubcategory> SearchLinqEF(Expression<Func<EFProductSubcategory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductSubcategory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductSubcategory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductSubcategory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductSubcategory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productSubcategoryID, int productCategoryID,
		                               string name,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductSubcategory   efProductSubcategory)
		{
			efProductSubcategory.productSubcategoryID = productSubcategoryID;
			efProductSubcategory.productCategoryID = productCategoryID;
			efProductSubcategory.name = name;
			efProductSubcategory.rowguid = rowguid;
			efProductSubcategory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductSubcategory efProductSubcategory,Response response)
		{
			if(efProductSubcategory == null)
			{
				return;
			}
			response.AddProductSubcategory(new POCOProductSubcategory()
			{
				ProductSubcategoryID = efProductSubcategory.productSubcategoryID.ToInt(),
				ProductCategoryID = efProductSubcategory.productCategoryID.ToInt(),
				Name = efProductSubcategory.name,
				Rowguid = efProductSubcategory.rowguid,
				ModifiedDate = efProductSubcategory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>82e693fb7502eb66a54c44aa81470e21</Hash>
</Codenesium>*/