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
	public abstract class AbstractProductCategoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductCategoryRepository(ILogger logger,
		                                         ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductCategory ();

			MapPOCOToEF(0, name,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFProductCategory>().Add(record);
			this._context.SaveChanges();
			return record.ProductCategoryID;
		}

		public virtual void Update(int productCategoryID, string name,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productCategoryID);
			}
			else
			{
				MapPOCOToEF(productCategoryID,  name,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productCategoryID)
		{
			var record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductCategory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productCategoryID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID,response);
		}

		protected virtual List<EFProductCategory> SearchLinqEF(Expression<Func<EFProductCategory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductCategory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductCategory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductCategory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductCategory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductCategory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productCategoryID, string name,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductCategory   efProductCategory)
		{
			efProductCategory.ProductCategoryID = productCategoryID;
			efProductCategory.Name = name;
			efProductCategory.Rowguid = rowguid;
			efProductCategory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductCategory efProductCategory,Response response)
		{
			if(efProductCategory == null)
			{
				return;
			}
			response.AddProductCategory(new POCOProductCategory()
			{
				ProductCategoryID = efProductCategory.ProductCategoryID.ToInt(),
				Name = efProductCategory.Name,
				Rowguid = efProductCategory.Rowguid,
				ModifiedDate = efProductCategory.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>aa02d75fcc6bde983fd4b2fa77739e84</Hash>
</Codenesium>*/