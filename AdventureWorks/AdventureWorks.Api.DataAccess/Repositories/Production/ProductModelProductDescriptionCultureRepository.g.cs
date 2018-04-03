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
	public abstract class AbstractProductModelProductDescriptionCultureRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductModelProductDescriptionCultureRepository(ILogger logger,
		                                                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int productDescriptionID,
		                          string cultureID,
		                          DateTime modifiedDate)
		{
			var record = new EFProductModelProductDescriptionCulture ();

			MapPOCOToEF(0, productDescriptionID,
			            cultureID,
			            modifiedDate, record);

			this._context.Set<EFProductModelProductDescriptionCulture>().Add(record);
			this._context.SaveChanges();
			return record.productModelID;
		}

		public virtual void Update(int productModelID, int productDescriptionID,
		                           string cultureID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productModelID);
			}
			else
			{
				MapPOCOToEF(productModelID,  productDescriptionID,
				            cultureID,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productModelID)
		{
			var record = this.SearchLinqEF(x => x.productModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductModelProductDescriptionCulture>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productModelID, Response response)
		{
			this.SearchLinqPOCO(x => x.productModelID == productModelID,response);
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEF(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productModelID, int productDescriptionID,
		                               string cultureID,
		                               DateTime modifiedDate, EFProductModelProductDescriptionCulture   efProductModelProductDescriptionCulture)
		{
			efProductModelProductDescriptionCulture.productModelID = productModelID;
			efProductModelProductDescriptionCulture.productDescriptionID = productDescriptionID;
			efProductModelProductDescriptionCulture.cultureID = cultureID;
			efProductModelProductDescriptionCulture.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture,Response response)
		{
			if(efProductModelProductDescriptionCulture == null)
			{
				return;
			}
			response.AddProductModelProductDescriptionCulture(new POCOProductModelProductDescriptionCulture()
			{
				ProductModelID = efProductModelProductDescriptionCulture.productModelID.ToInt(),
				ProductDescriptionID = efProductModelProductDescriptionCulture.productDescriptionID.ToInt(),
				CultureID = efProductModelProductDescriptionCulture.cultureID,
				ModifiedDate = efProductModelProductDescriptionCulture.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>8bfc9612cd5cc55ac94c5e2c37932394</Hash>
</Codenesium>*/