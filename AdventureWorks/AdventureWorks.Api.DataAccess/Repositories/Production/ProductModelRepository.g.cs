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
	public abstract class AbstractProductModelRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductModelRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          string catalogDescription,
		                          string instructions,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductModel ();

			MapPOCOToEF(0, name,
			            catalogDescription,
			            instructions,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFProductModel>().Add(record);
			this._context.SaveChanges();
			return record.ProductModelID;
		}

		public virtual void Update(int productModelID, string name,
		                           string catalogDescription,
		                           string instructions,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productModelID);
			}
			else
			{
				MapPOCOToEF(productModelID,  name,
				            catalogDescription,
				            instructions,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productModelID)
		{
			var record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductModel>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productModelID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductModelID == productModelID,response);
		}

		protected virtual List<EFProductModel> SearchLinqEF(Expression<Func<EFProductModel, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductModel> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductModel, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductModel, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModel> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductModel> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productModelID, string name,
		                               string catalogDescription,
		                               string instructions,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductModel   efProductModel)
		{
			efProductModel.ProductModelID = productModelID;
			efProductModel.Name = name;
			efProductModel.CatalogDescription = catalogDescription;
			efProductModel.Instructions = instructions;
			efProductModel.Rowguid = rowguid;
			efProductModel.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductModel efProductModel,Response response)
		{
			if(efProductModel == null)
			{
				return;
			}
			response.AddProductModel(new POCOProductModel()
			{
				ProductModelID = efProductModel.ProductModelID.ToInt(),
				Name = efProductModel.Name,
				CatalogDescription = efProductModel.CatalogDescription,
				Instructions = efProductModel.Instructions,
				Rowguid = efProductModel.Rowguid,
				ModifiedDate = efProductModel.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>dd81be68db01013c9dd04a9cc1cde987</Hash>
</Codenesium>*/