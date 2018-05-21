using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractDeviceActionRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDeviceActionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCODeviceAction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCODeviceAction> Get(int id)
		{
			DeviceAction record = await this.GetById(id);

			return this.Mapper.DeviceActionMapEFToPOCO(record);
		}

		public async virtual Task<POCODeviceAction> Create(
			ApiDeviceActionModel model)
		{
			DeviceAction record = new DeviceAction();

			this.Mapper.DeviceActionMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<DeviceAction>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.DeviceActionMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiDeviceActionModel model)
		{
			DeviceAction record = await this.GetById(id);

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

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			DeviceAction record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DeviceAction>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCODeviceAction>> Where(Expression<Func<DeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODeviceAction> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCODeviceAction>> SearchLinqPOCO(Expression<Func<DeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODeviceAction> response = new List<POCODeviceAction>();
			List<DeviceAction> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.DeviceActionMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<DeviceAction>> SearchLinqEF(Expression<Func<DeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DeviceAction.Id)} ASC";
			}
			return await this.Context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DeviceAction>();
		}

		private async Task<List<DeviceAction>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DeviceAction.Id)} ASC";
			}

			return await this.Context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DeviceAction>();
		}

		private async Task<DeviceAction> GetById(int id)
		{
			List<DeviceAction> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c7e9747d589844b0c9f50994a317817d</Hash>
</Codenesium>*/