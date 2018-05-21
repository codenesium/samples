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
	public abstract class AbstractDeviceRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDeviceRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCODevice>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCODevice> Get(int id)
		{
			Device record = await this.GetById(id);

			return this.Mapper.DeviceMapEFToPOCO(record);
		}

		public async virtual Task<POCODevice> Create(
			ApiDeviceModel model)
		{
			Device record = new Device();

			this.Mapper.DeviceMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Device>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.DeviceMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiDeviceModel model)
		{
			Device record = await this.GetById(id);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Device record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Device>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCODevice> PublicId(Guid publicId)
		{
			var records = await this.SearchLinqPOCO(x => x.PublicId == publicId);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCODevice>> Where(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODevice> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCODevice>> SearchLinqPOCO(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODevice> response = new List<POCODevice>();
			List<Device> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.DeviceMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Device>> SearchLinqEF(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Device.Id)} ASC";
			}
			return await this.Context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Device>();
		}

		private async Task<List<Device>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Device.Id)} ASC";
			}

			return await this.Context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Device>();
		}

		private async Task<Device> GetById(int id)
		{
			List<Device> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>99abede6be5562cac11cda13c3a80630</Hash>
</Codenesium>*/