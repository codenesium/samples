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
		                          string name,
		                          string @value)
		{
			var record = new EFDeviceAction ();

			MapPOCOToEF(0, deviceId,
			            name,
			            @value, record);

			this._context.Set<EFDeviceAction>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, int deviceId,
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
				MapPOCOToEF(id,  deviceId,
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
				this._context.Set<EFDeviceAction>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<EFDeviceAction> SearchLinqEF(Expression<Func<EFDeviceAction, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDeviceAction> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFDeviceAction, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFDeviceAction, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDeviceAction> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDeviceAction> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, int deviceId,
		                               string name,
		                               string @value, EFDeviceAction   efDeviceAction)
		{
			efDeviceAction.id = id;
			efDeviceAction.deviceId = deviceId;
			efDeviceAction.name = name;
			efDeviceAction.@value = @value;
		}

		public static void MapEFToPOCO(EFDeviceAction efDeviceAction,Response response)
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
    <Hash>6c3c9d0519aaa8fb12ba87df1abe2edb</Hash>
</Codenesium>*/