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
	public abstract class AbstractProductInventoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductInventoryRepository(ILogger logger,
		                                          ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(short locationID,
		                          string shelf,
		                          int bin,
		                          short quantity,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFProductInventory ();

			MapPOCOToEF(0, locationID,
			            shelf,
			            bin,
			            quantity,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFProductInventory>().Add(record);
			this._context.SaveChanges();
			return record.productID;
		}

		public virtual void Update(int productID, short locationID,
		                           string shelf,
		                           int bin,
		                           short quantity,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  locationID,
				            shelf,
				            bin,
				            quantity,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productID)
		{
			var record = this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductInventory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.productID == productID,response);
		}

		protected virtual List<EFProductInventory> SearchLinqEF(Expression<Func<EFProductInventory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductInventory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductInventory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFProductInventory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductInventory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductInventory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productID, short locationID,
		                               string shelf,
		                               int bin,
		                               short quantity,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFProductInventory   efProductInventory)
		{
			efProductInventory.productID = productID;
			efProductInventory.locationID = locationID;
			efProductInventory.shelf = shelf;
			efProductInventory.bin = bin;
			efProductInventory.quantity = quantity;
			efProductInventory.rowguid = rowguid;
			efProductInventory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductInventory efProductInventory,Response response)
		{
			if(efProductInventory == null)
			{
				return;
			}
			response.AddProductInventory(new POCOProductInventory()
			{
				ProductID = efProductInventory.productID.ToInt(),
				LocationID = efProductInventory.locationID,
				Shelf = efProductInventory.shelf,
				Bin = efProductInventory.bin,
				Quantity = efProductInventory.quantity,
				Rowguid = efProductInventory.rowguid,
				ModifiedDate = efProductInventory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>41aaa62ab3dad20347582c5a903434db</Hash>
</Codenesium>*/