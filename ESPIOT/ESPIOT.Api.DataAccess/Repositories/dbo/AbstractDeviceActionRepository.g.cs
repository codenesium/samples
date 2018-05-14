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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDeviceActionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCODeviceAction Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCODeviceAction Create(
			DeviceActionModel model)
		{
			DeviceAction record = new DeviceAction();

			this.Mapper.DeviceActionMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<DeviceAction>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.DeviceActionMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			DeviceActionModel model)
		{
			DeviceAction record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.DeviceActionMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			DeviceAction record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DeviceAction>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCODeviceAction> Where(Expression<Func<DeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODeviceAction> SearchLinqPOCO(Expression<Func<DeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODeviceAction> response = new List<POCODeviceAction>();
			List<DeviceAction> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DeviceActionMapEFToPOCO(x)));
			return response;
		}

		private List<DeviceAction> SearchLinqEF(Expression<Func<DeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DeviceAction.Id)} ASC";
			}
			return this.Context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<DeviceAction>();
		}

		private List<DeviceAction> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DeviceAction.Id)} ASC";
			}

			return this.Context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<DeviceAction>();
		}
	}
}

/*<Codenesium>
    <Hash>1a5a8b45bb66807379c75a035a10b9fa</Hash>
</Codenesium>*/