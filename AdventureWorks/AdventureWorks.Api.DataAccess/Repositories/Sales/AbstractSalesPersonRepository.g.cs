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
	public abstract class AbstractSalesPersonRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesPersonRepository(ILogger logger,
		                                     ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(Nullable<int> territoryID,
		                          Nullable<decimal> salesQuota,
		                          decimal bonus,
		                          decimal commissionPct,
		                          decimal salesYTD,
		                          decimal salesLastYear,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesPerson ();

			MapPOCOToEF(0, territoryID,
			            salesQuota,
			            bonus,
			            commissionPct,
			            salesYTD,
			            salesLastYear,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFSalesPerson>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, Nullable<int> territoryID,
		                           Nullable<decimal> salesQuota,
		                           decimal bonus,
		                           decimal commissionPct,
		                           decimal salesYTD,
		                           decimal salesLastYear,
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
				MapPOCOToEF(businessEntityID,  territoryID,
				            salesQuota,
				            bonus,
				            commissionPct,
				            salesYTD,
				            salesLastYear,
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
				this.context.Set<EFSalesPerson>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOSalesPerson GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.SalesPersons.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesPerson> GetWhereDirect(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesPersons;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesPerson, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPerson> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPerson> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFSalesPerson> SearchLinqEF(Expression<Func<EFSalesPerson, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesPerson> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int businessEntityID, Nullable<int> territoryID,
		                               Nullable<decimal> salesQuota,
		                               decimal bonus,
		                               decimal commissionPct,
		                               decimal salesYTD,
		                               decimal salesLastYear,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesPerson   efSalesPerson)
		{
			efSalesPerson.BusinessEntityID = businessEntityID;
			efSalesPerson.TerritoryID = territoryID;
			efSalesPerson.SalesQuota = salesQuota;
			efSalesPerson.Bonus = bonus;
			efSalesPerson.CommissionPct = commissionPct;
			efSalesPerson.SalesYTD = salesYTD;
			efSalesPerson.SalesLastYear = salesLastYear;
			efSalesPerson.Rowguid = rowguid;
			efSalesPerson.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesPerson efSalesPerson,Response response)
		{
			if(efSalesPerson == null)
			{
				return;
			}
			response.AddSalesPerson(new POCOSalesPerson()
			{
				SalesQuota = efSalesPerson.SalesQuota,
				Bonus = efSalesPerson.Bonus,
				CommissionPct = efSalesPerson.CommissionPct,
				SalesYTD = efSalesPerson.SalesYTD,
				SalesLastYear = efSalesPerson.SalesLastYear,
				Rowguid = efSalesPerson.Rowguid,
				ModifiedDate = efSalesPerson.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efSalesPerson.BusinessEntityID,
				                                            "Employees"),
				TerritoryID = new ReferenceEntity<Nullable<int>>(efSalesPerson.TerritoryID,
				                                                 "SalesTerritories"),
			});

			EmployeeRepository.MapEFToPOCO(efSalesPerson.Employee, response);

			SalesTerritoryRepository.MapEFToPOCO(efSalesPerson.SalesTerritory, response);
		}
	}
}

/*<Codenesium>
    <Hash>a3a1a2db7d228ebe1432ac700e60c1d3</Hash>
</Codenesium>*/