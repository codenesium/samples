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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDeviceRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCODevice Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCODevice Create(
			DeviceModel model)
		{
			Device record = new Device();

			this.Mapper.DeviceMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Device>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.DeviceMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			DeviceModel model)
		{
			Device record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.DeviceMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Device record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Device>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCODevice PublicId(Guid publicId)
		{
			return this.SearchLinqPOCO(x => x.PublicId == publicId).FirstOrDefault();
		}

		protected List<POCODevice> Where(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODevice> SearchLinqPOCO(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODevice> response = new List<POCODevice>();
			List<Device> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DeviceMapEFToPOCO(x)));
			return response;
		}

		private List<Device> SearchLinqEF(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Device.Id)} ASC";
			}
			return this.Context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Device>();
		}

		private List<Device> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Device.Id)} ASC";
			}

			return this.Context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Device>();
		}
	}
}

/*<Codenesium>
    <Hash>f99863b8db4bbb6f5130e75a4a2f5cea</Hash>
</Codenesium>*/