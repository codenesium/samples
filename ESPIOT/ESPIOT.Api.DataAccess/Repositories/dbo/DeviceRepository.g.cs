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
	public abstract class AbstractDeviceRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractDeviceRepository(ILogger logger,
		                                ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          Guid publicId)
		{
			var record = new Device ();

			MapPOCOToEF(0, name,
			            publicId, record);

			this._context.Set<Device>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, string name,
		                           Guid publicId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            publicId, record);
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
				this._context.Set<Device>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<Device> SearchLinqEF(Expression<Func<Device, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<Device> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<Device, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Device, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Device> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Device> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name,
		                               Guid publicId, Device   efDevice)
		{
			efDevice.id = id;
			efDevice.name = name;
			efDevice.publicId = publicId;
		}

		public static void MapEFToPOCO(Device efDevice,Response response)
		{
			if(efDevice == null)
			{
				return;
			}
			response.AddDevice(new POCODevice()
			{
				Id = efDevice.id.ToInt(),
				Name = efDevice.name,
				PublicId = efDevice.publicId,
			});
		}
	}
}

/*<Codenesium>
    <Hash>e362c9a661ddc45623979c512f9a81cf</Hash>
</Codenesium>*/