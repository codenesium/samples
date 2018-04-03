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
	public abstract class AbstractBillOfMaterialsRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractBillOfMaterialsRepository(ILogger logger,
		                                         ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Nullable<int> productAssemblyID,
		                          int componentID,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          string unitMeasureCode,
		                          short bOMLevel,
		                          decimal perAssemblyQty,
		                          DateTime modifiedDate)
		{
			var record = new EFBillOfMaterials ();

			MapPOCOToEF(0, productAssemblyID,
			            componentID,
			            startDate,
			            endDate,
			            unitMeasureCode,
			            bOMLevel,
			            perAssemblyQty,
			            modifiedDate, record);

			this._context.Set<EFBillOfMaterials>().Add(record);
			this._context.SaveChanges();
			return record.billOfMaterialsID;
		}

		public virtual void Update(int billOfMaterialsID, Nullable<int> productAssemblyID,
		                           int componentID,
		                           DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           string unitMeasureCode,
		                           short bOMLevel,
		                           decimal perAssemblyQty,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.billOfMaterialsID == billOfMaterialsID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",billOfMaterialsID);
			}
			else
			{
				MapPOCOToEF(billOfMaterialsID,  productAssemblyID,
				            componentID,
				            startDate,
				            endDate,
				            unitMeasureCode,
				            bOMLevel,
				            perAssemblyQty,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int billOfMaterialsID)
		{
			var record = this.SearchLinqEF(x => x.billOfMaterialsID == billOfMaterialsID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFBillOfMaterials>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int billOfMaterialsID, Response response)
		{
			this.SearchLinqPOCO(x => x.billOfMaterialsID == billOfMaterialsID,response);
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFBillOfMaterials, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int billOfMaterialsID, Nullable<int> productAssemblyID,
		                               int componentID,
		                               DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               string unitMeasureCode,
		                               short bOMLevel,
		                               decimal perAssemblyQty,
		                               DateTime modifiedDate, EFBillOfMaterials   efBillOfMaterials)
		{
			efBillOfMaterials.billOfMaterialsID = billOfMaterialsID;
			efBillOfMaterials.productAssemblyID = productAssemblyID;
			efBillOfMaterials.componentID = componentID;
			efBillOfMaterials.startDate = startDate;
			efBillOfMaterials.endDate = endDate;
			efBillOfMaterials.unitMeasureCode = unitMeasureCode;
			efBillOfMaterials.bOMLevel = bOMLevel;
			efBillOfMaterials.perAssemblyQty = perAssemblyQty;
			efBillOfMaterials.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFBillOfMaterials efBillOfMaterials,Response response)
		{
			if(efBillOfMaterials == null)
			{
				return;
			}
			response.AddBillOfMaterials(new POCOBillOfMaterials()
			{
				BillOfMaterialsID = efBillOfMaterials.billOfMaterialsID.ToInt(),
				ProductAssemblyID = efBillOfMaterials.productAssemblyID.ToNullableInt(),
				ComponentID = efBillOfMaterials.componentID.ToInt(),
				StartDate = efBillOfMaterials.startDate.ToDateTime(),
				EndDate = efBillOfMaterials.endDate.ToNullableDateTime(),
				UnitMeasureCode = efBillOfMaterials.unitMeasureCode,
				BOMLevel = efBillOfMaterials.bOMLevel,
				PerAssemblyQty = efBillOfMaterials.perAssemblyQty.ToDecimal(),
				ModifiedDate = efBillOfMaterials.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>d06749921cbd45fbb33ade2a31432f97</Hash>
</Codenesium>*/