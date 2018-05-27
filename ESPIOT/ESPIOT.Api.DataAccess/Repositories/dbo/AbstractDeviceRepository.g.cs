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
		protected IDALDeviceMapper Mapper { get; }

		public AbstractDeviceRepository(
			IDALDeviceMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTODevice>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTODevice> Get(int id)
		{
			Device record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTODevice> Create(
			DTODevice dto)
		{
			Device record = new Device();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Device>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTODevice dto)
		{
			Device record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					id,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTODevice> PublicId(Guid publicId)
		{
			var records = await this.SearchLinqDTO(x => x.PublicId == publicId);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTODevice>> Where(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODevice> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTODevice>> SearchLinqDTO(Expression<Func<Device, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODevice> response = new List<DTODevice>();
			List<Device> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>0c2804c4f710cd456147a9a26952212a</Hash>
</Codenesium>*/