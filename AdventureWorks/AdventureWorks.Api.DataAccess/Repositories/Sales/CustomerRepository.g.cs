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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractCustomerRepository(ILogger logger,
		                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFCustomer>().Add(record);
			this._context.SaveChanges();
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
				this._logger.LogError("Unable to find id:{0}",customerID);
			}
			else
			{
				MapPOCOToEF(customerID,  personID,
				            storeID,
				            territoryID,
				            accountNumber,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
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
				this._context.Set<EFCustomer>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int customerID, Response response)
		{
			this.SearchLinqPOCO(x => x.CustomerID == customerID,response);
		}

		protected virtual List<EFCustomer> SearchLinqEF(Expression<Func<EFCustomer, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCustomer> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFCustomer, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
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

		public static void MapPOCOToEF(int customerID, Nullable<int> personID,
		                               Nullable<int> storeID,
		                               Nullable<int> territoryID,
		                               string accountNumber,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFCustomer   efCustomer)
		{
			efCustomer.CustomerID = customerID;
			efCustomer.PersonID = personID;
			efCustomer.StoreID = storeID;
			efCustomer.TerritoryID = territoryID;
			efCustomer.AccountNumber = accountNumber;
			efCustomer.rowguid = rowguid;
			efCustomer.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCustomer efCustomer,Response response)
		{
			if(efCustomer == null)
			{
				return;
			}
			response.AddCustomer(new POCOCustomer()
			{
				CustomerID = efCustomer.CustomerID.ToInt(),
				AccountNumber = efCustomer.AccountNumber,
				Rowguid = efCustomer.rowguid,
				ModifiedDate = efCustomer.ModifiedDate.ToDateTime(),

				PersonID = new ReferenceEntity<Nullable<int>>(efCustomer.PersonID,
				                                              "People"),
				StoreID = new ReferenceEntity<Nullable<int>>(efCustomer.StoreID,
				                                             "Stores"),
				TerritoryID = new ReferenceEntity<Nullable<int>>(efCustomer.TerritoryID,
				                                                 "SalesTerritories"),
			});

			PersonRepository.MapEFToPOCO(efCustomer.PersonRef, response);

			StoreRepository.MapEFToPOCO(efCustomer.StoreRef, response);

			SalesTerritoryRepository.MapEFToPOCO(efCustomer.SalesTerritoryRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>447275b719e6ea150cee6ecb984c9908</Hash>
</Codenesium>*/