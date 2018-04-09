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
				this.logger.LogError($"Unable to find id:{id}");
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

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response;
		}

		public virtual POCODevice GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.Devices.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCODevice> GetWhereDirect(Expression<Func<EFDevice, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Devices;
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

		protected virtual List<EFDevice> SearchLinqEF(Expression<Func<EFDevice, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDevice> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int id, Guid publicId,
		                               string name, EFDevice   efDevice)
		{
			efDevice.SetProperties(id.ToInt(),publicId,name);
		}

		public static void MapEFToPOCO(EFDevice efDevice,Response response)
		{
			if(efDevice == null)
			{
				return;
			}
			response.AddDevice(new POCODevice(efDevice.Id.ToInt(),efDevice.PublicId,efDevice.Name));
		}
	}
}

/*<Codenesium>
    <Hash>c5bbf9dcc4918d07caf3627fc039b3b7</Hash>
</Codenesium>*/