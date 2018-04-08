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
	public abstract class AbstractShipMethodRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractShipMethodRepository(ILogger logger,
		                                    ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          decimal shipBase,
		                          decimal shipRate,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFShipMethod ();

			MapPOCOToEF(0, name,
			            shipBase,
			            shipRate,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFShipMethod>().Add(record);
			this.context.SaveChanges();
			return record.ShipMethodID;
		}

		public virtual void Update(int shipMethodID, string name,
		                           decimal shipBase,
		                           decimal shipRate,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ShipMethodID == shipMethodID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",shipMethodID);
			}
			else
			{
				MapPOCOToEF(shipMethodID,  name,
				            shipBase,
				            shipRate,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int shipMethodID)
		{
			var record = this.SearchLinqEF(x => x.ShipMethodID == shipMethodID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFShipMethod>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int shipMethodID, Response response)
		{
			this.SearchLinqPOCO(x => x.ShipMethodID == shipMethodID,response);
		}

		protected virtual List<EFShipMethod> SearchLinqEF(Expression<Func<EFShipMethod, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShipMethod> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFShipMethod, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOShipMethod > GetWhereDirect(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ShipMethods;
		}
		public virtual POCOShipMethod GetByIdDirect(int shipMethodID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ShipMethodID == shipMethodID,response);
			return response.ShipMethods.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFShipMethod, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFShipMethod> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFShipMethod> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int shipMethodID, string name,
		                               decimal shipBase,
		                               decimal shipRate,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFShipMethod   efShipMethod)
		{
			efShipMethod.ShipMethodID = shipMethodID;
			efShipMethod.Name = name;
			efShipMethod.ShipBase = shipBase;
			efShipMethod.ShipRate = shipRate;
			efShipMethod.Rowguid = rowguid;
			efShipMethod.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFShipMethod efShipMethod,Response response)
		{
			if(efShipMethod == null)
			{
				return;
			}
			response.AddShipMethod(new POCOShipMethod()
			{
				ShipMethodID = efShipMethod.ShipMethodID.ToInt(),
				Name = efShipMethod.Name,
				ShipBase = efShipMethod.ShipBase,
				ShipRate = efShipMethod.ShipRate,
				Rowguid = efShipMethod.Rowguid,
				ModifiedDate = efShipMethod.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>6b344140a50f15fe710ac3f7f33ec719</Hash>
</Codenesium>*/