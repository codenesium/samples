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
	public abstract class AbstractCustomerRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractCustomerRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(Nullable<int> personID,
		                          Nullable<int> storeID,
		                          Nullable<int> territoryID,
		                          string accountNumber,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFCustomer ();

			MapPOCOToEF(0, personID,
			            storeID,
			            territoryID,
			            accountNumber,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFCustomer>().Add(record);
			this.context.SaveChanges();
			return record.CustomerID;
		}

		public virtual void Update(int customerID, Nullable<int> personID,
		                           Nullable<int> storeID,
		                           Nullable<int> territoryID,
		                           string accountNumber,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{customerID}");
			}
			else
			{
				MapPOCOToEF(customerID,  personID,
				            storeID,
				            territoryID,
				            accountNumber,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int customerID)
		{
			var record = this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCustomer>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int customerID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CustomerID == customerID,response);
			return response;
		}

		public virtual POCOCustomer GetByIdDirect(int customerID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CustomerID == customerID,response);
			return response.Customers.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCustomer> GetWhereDirect(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Customers;
		}

		private void SearchLinqPOCO(Expression<Func<EFCustomer, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCustomer> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCustomer> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFCustomer> SearchLinqEF(Expression<Func<EFCustomer, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCustomer> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int customerID, Nullable<int> personID,
		                               Nullable<int> storeID,
		                               Nullable<int> territoryID,
		                               string accountNumber,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFCustomer   efCustomer)
		{
			efCustomer.SetProperties(customerID.ToInt(),personID.ToNullableInt(),storeID.ToNullableInt(),territoryID.ToNullableInt(),accountNumber,rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFCustomer efCustomer,Response response)
		{
			if(efCustomer == null)
			{
				return;
			}
			response.AddCustomer(new POCOCustomer(efCustomer.CustomerID.ToInt(),efCustomer.PersonID.ToNullableInt(),efCustomer.StoreID.ToNullableInt(),efCustomer.TerritoryID.ToNullableInt(),efCustomer.AccountNumber,efCustomer.Rowguid,efCustomer.ModifiedDate.ToDateTime()));

			PersonRepository.MapEFToPOCO(efCustomer.Person, response);

			StoreRepository.MapEFToPOCO(efCustomer.Store, response);

			SalesTerritoryRepository.MapEFToPOCO(efCustomer.SalesTerritory, response);
		}
	}
}

/*<Codenesium>
    <Hash>1c1d409944015f3c1aad13d1ffa89b8c</Hash>
</Codenesium>*/