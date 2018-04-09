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
	public abstract class AbstractStoreRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractStoreRepository(ILogger logger,
		                               ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          Nullable<int> salesPersonID,
		                          string demographics,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFStore ();

			MapPOCOToEF(0, name,
			            salesPersonID,
			            demographics,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFStore>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, string name,
		                           Nullable<int> salesPersonID,
		                           string demographics,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  name,
				            salesPersonID,
				            demographics,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFStore>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOStore GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.Stores.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOStore> GetWhereDirect(Expression<Func<EFStore, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Stores;
		}

		private void SearchLinqPOCO(Expression<Func<EFStore, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFStore> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFStore> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFStore> SearchLinqEF(Expression<Func<EFStore, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStore> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int businessEntityID, string name,
		                               Nullable<int> salesPersonID,
		                               string demographics,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFStore   efStore)
		{
			efStore.BusinessEntityID = businessEntityID;
			efStore.Name = name;
			efStore.SalesPersonID = salesPersonID;
			efStore.Demographics = demographics;
			efStore.Rowguid = rowguid;
			efStore.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFStore efStore,Response response)
		{
			if(efStore == null)
			{
				return;
			}
			response.AddStore(new POCOStore()
			{
				Name = efStore.Name,
				Demographics = efStore.Demographics,
				Rowguid = efStore.Rowguid,
				ModifiedDate = efStore.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efStore.BusinessEntityID,
				                                            "BusinessEntities"),
				SalesPersonID = new ReferenceEntity<Nullable<int>>(efStore.SalesPersonID,
				                                                   "SalesPersons"),
			});

			BusinessEntityRepository.MapEFToPOCO(efStore.BusinessEntity, response);

			SalesPersonRepository.MapEFToPOCO(efStore.SalesPerson, response);
		}
	}
}

/*<Codenesium>
    <Hash>d362b4b66447cbf9be8fa0c798b9c86e</Hash>
</Codenesium>*/