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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductSubcategoryRepository(ILogger logger,
		                                            ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFProductSubcategory>().Add(record);
			this.context.SaveChanges();
			return record.ProductSubcategoryID;
		}

		public virtual void Update(int productSubcategoryID, int productCategoryID,
		                           string name,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productSubcategoryID);
			}
			else
			{
				MapPOCOToEF(productSubcategoryID,  productCategoryID,
				            name,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productSubcategoryID)
		{
			var record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductSubcategory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productSubcategoryID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID,response);
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

		public virtual List<POCOProductSubcategory > GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductSubcategories;
		}
		public virtual POCOProductSubcategory GetByIdDirect(int productSubcategoryID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID,response);
			return response.ProductSubcategories.FirstOrDefault();
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
			efProductSubcategory.ProductSubcategoryID = productSubcategoryID;
			efProductSubcategory.ProductCategoryID = productCategoryID;
			efProductSubcategory.Name = name;
			efProductSubcategory.Rowguid = rowguid;
			efProductSubcategory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductSubcategory efProductSubcategory,Response response)
		{
			if(efProductSubcategory == null)
			{
				return;
			}
			response.AddProductSubcategory(new POCOProductSubcategory()
			{
				ProductSubcategoryID = efProductSubcategory.ProductSubcategoryID.ToInt(),
				Name = efProductSubcategory.Name,
				Rowguid = efProductSubcategory.Rowguid,
				ModifiedDate = efProductSubcategory.ModifiedDate.ToDateTime(),

				ProductCategoryID = new ReferenceEntity<int>(efProductSubcategory.ProductCategoryID,
				                                             "ProductCategories"),
			});

			ProductCategoryRepository.MapEFToPOCO(efProductSubcategory.ProductCategory, response);
		}
	}
}

/*<Codenesium>
    <Hash>d3e46435086c12cbb1ef1b197fae9bdf</Hash>
</Codenesium>*/