using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractAirTransportRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALAirTransportMapper Mapper { get; }

		public AbstractAirTransportRepository(
			IDALAirTransportMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOAirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOAirTransport> Get(int airlineId)
		{
			AirTransport record = await this.GetById(airlineId);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOAirTransport> Create(
			DTOAirTransport dto)
		{
			AirTransport record = new AirTransport();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<AirTransport>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int airlineId,
			DTOAirTransport dto)
		{
			AirTransport record = await this.GetById(airlineId);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{airlineId}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					airlineId,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int airlineId)
		{
			AirTransport record = await this.GetById(airlineId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AirTransport>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOAirTransport>> Where(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAirTransport> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOAirTransport>> SearchLinqDTO(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAirTransport> response = new List<DTOAirTransport>();
			List<AirTransport> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<AirTransport>> SearchLinqEF(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AirTransport.AirlineId)} ASC";
			}
			return await this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AirTransport>();
		}

		private async Task<List<AirTransport>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AirTransport.AirlineId)} ASC";
			}

			return await this.Context.Set<AirTransport>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AirTransport>();
		}

		private async Task<AirTransport> GetById(int airlineId)
		{
			List<AirTransport> records = await this.SearchLinqEF(x => x.AirlineId == airlineId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8edcc25a3289b50a4471354a624cea77</Hash>
</Codenesium>*/