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
		protected IObjectMapper Mapper { get; }

		public AbstractAirTransportRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOAirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOAirTransport> Get(int airlineId)
		{
			AirTransport record = await this.GetById(airlineId);

			return this.Mapper.AirTransportMapEFToPOCO(record);
		}

		public async virtual Task<POCOAirTransport> Create(
			ApiAirTransportModel model)
		{
			AirTransport record = new AirTransport();

			this.Mapper.AirTransportMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<AirTransport>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.AirTransportMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int airlineId,
			ApiAirTransportModel model)
		{
			AirTransport record = await this.GetById(airlineId);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{airlineId}");
			}
			else
			{
				this.Mapper.AirTransportMapModelToEF(
					airlineId,
					model,
					record);
				this.Context.SaveChangesAsync();
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

		protected async Task<List<POCOAirTransport>> Where(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAirTransport> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOAirTransport>> SearchLinqPOCO(Expression<Func<AirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAirTransport> response = new List<POCOAirTransport>();
			List<AirTransport> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.AirTransportMapEFToPOCO(x)));
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
    <Hash>34a99301bb98cec8f67b69ced36b5636</Hash>
</Codenesium>*/