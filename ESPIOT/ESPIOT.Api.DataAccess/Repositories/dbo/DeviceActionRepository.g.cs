using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractDeviceActionRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractDeviceActionRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int deviceId,
		                          int id,
		                          string name,
		                          string @value)
		{
			var record = new DeviceAction ();

			MapPOCOToEF(deviceId,
			            id,
			            name,
			            @value, record);

			this._context.Set<DeviceAction>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int deviceId,
		                           int id,
		                           string name,
		                           string @value)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(deviceId,
				            id,
				            name,
				            @value, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<DeviceAction>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<DeviceAction> SearchLinqEF(Expression<Func<DeviceAction, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<DeviceAction> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<DeviceAction, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<DeviceAction, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<DeviceAction> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<DeviceAction> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int deviceId,
		                               int id,
		                               string name,
		                               string @value, DeviceAction   efDeviceAction)
		{
			efDeviceAction.deviceId = deviceId;
			efDeviceAction.id = id;
			efDeviceAction.name = name;
			efDeviceAction.@value = @value;
		}

		public static void MapEFToPOCO(DeviceAction efDeviceAction,Response response)
		{
			if(efDeviceAction == null)
			{
				return;
			}
			response.AddDeviceAction(new POCODeviceAction()
			{
				Id = efDeviceAction.id.ToInt(),
				Name = efDeviceAction.name,
				@Value = efDeviceAction.@value,

				DeviceId = new ReferenceEntity<int>(efDeviceAction.deviceId,
				                                    "Devices"),
			});

			DeviceRepository.MapEFToPOCO(efDeviceAction.DeviceRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>503a58b5c2ee37a30a9a32e3d9a3dc48</Hash>
</Codenesium>*/