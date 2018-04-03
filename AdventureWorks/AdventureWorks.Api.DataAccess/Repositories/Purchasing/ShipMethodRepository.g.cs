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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractShipMethodRepository(ILogger logger,
		                                    ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFShipMethod>().Add(record);
			this._context.SaveChanges();
			return record.shipMethodID;
		}

		public virtual void Update(int shipMethodID, string name,
		                           decimal shipBase,
		                           decimal shipRate,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.shipMethodID == shipMethodID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",shipMethodID);
			}
			else
			{
				MapPOCOToEF(shipMethodID,  name,
				            shipBase,
				            shipRate,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int shipMethodID)
		{
			var record = this.SearchLinqEF(x => x.shipMethodID == shipMethodID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFShipMethod>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int shipMethodID, Response response)
		{
			this.SearchLinqPOCO(x => x.shipMethodID == shipMethodID,response);
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
			efShipMethod.shipMethodID = shipMethodID;
			efShipMethod.name = name;
			efShipMethod.shipBase = shipBase;
			efShipMethod.shipRate = shipRate;
			efShipMethod.rowguid = rowguid;
			efShipMethod.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFShipMethod efShipMethod,Response response)
		{
			if(efShipMethod == null)
			{
				return;
			}
			response.AddShipMethod(new POCOShipMethod()
			{
				ShipMethodID = efShipMethod.shipMethodID.ToInt(),
				Name = efShipMethod.name,
				ShipBase = efShipMethod.shipBase,
				ShipRate = efShipMethod.shipRate,
				Rowguid = efShipMethod.rowguid,
				ModifiedDate = efShipMethod.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>00ec17f602d796ef2b25b8de2e7dd3ae</Hash>
</Codenesium>*/