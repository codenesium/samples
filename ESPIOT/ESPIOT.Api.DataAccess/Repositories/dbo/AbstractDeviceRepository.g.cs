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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractDeviceRepository(ILogger logger,
		                                ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(Guid publicId,
		                          string name)
		{
			var record = new EFDevice ();

			MapPOCOToEF(0, publicId,
			            name, record);

			this.context.Set<EFDevice>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, Guid publicId,
		                           string name)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  publicId,
				            name, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFDevice>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFDevice> SearchLinqEF(Expression<Func<EFDevice, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDevice> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFDevice, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCODevice > GetWhereDirect(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Devices;
		}
		public virtual POCODevice GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Devices.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFDevice, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDevice> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDevice> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, Guid publicId,
		                               string name, EFDevice   efDevice)
		{
			efDevice.Id = id;
			efDevice.PublicId = publicId;
			efDevice.Name = name;
		}

		public static void MapEFToPOCO(EFDevice efDevice,Response response)
		{
			if(efDevice == null)
			{
				return;
			}
			response.AddDevice(new POCODevice()
			{
				Id = efDevice.Id.ToInt(),
				PublicId = efDevice.PublicId,
				Name = efDevice.Name,
			});
		}
	}
}

/*<Codenesium>
    <Hash>cd2a8c98710a6e4b5f04c0005a79d6c3</Hash>
</Codenesium>*/