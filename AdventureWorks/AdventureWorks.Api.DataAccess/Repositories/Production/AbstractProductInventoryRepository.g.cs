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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductInventoryRepository(ILogger logger,
		                                          ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFProductInventory>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(int productID, short locationID,
		                           string shelf,
		                           int bin,
		                           short quantity,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  locationID,
				            shelf,
				            bin,
				            quantity,
				            rowguid,
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
				this.context.Set<EFProductInventory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductID == productID,response);
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

		public virtual List<POCOProductInventory> GetWhereDirect(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductInventories;
		}
		public virtual POCOProductInventory GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID,response);
			return response.ProductInventories.FirstOrDefault();
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
			efProductInventory.ProductID = productID;
			efProductInventory.LocationID = locationID;
			efProductInventory.Shelf = shelf;
			efProductInventory.Bin = bin;
			efProductInventory.Quantity = quantity;
			efProductInventory.Rowguid = rowguid;
			efProductInventory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductInventory efProductInventory,Response response)
		{
			if(efProductInventory == null)
			{
				return;
			}
			response.AddProductInventory(new POCOProductInventory()
			{
				Shelf = efProductInventory.Shelf,
				Bin = efProductInventory.Bin,
				Quantity = efProductInventory.Quantity,
				Rowguid = efProductInventory.Rowguid,
				ModifiedDate = efProductInventory.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efProductInventory.ProductID,
				                                     "Products"),
				LocationID = new ReferenceEntity<short>(efProductInventory.LocationID,
				                                        "Locations"),
			});

			ProductRepository.MapEFToPOCO(efProductInventory.Product, response);

			LocationRepository.MapEFToPOCO(efProductInventory.Location, response);
		}
	}
}

/*<Codenesium>
    <Hash>a8722f300947a48282f8615c3d771011</Hash>
</Codenesium>*/