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
	public abstract class AbstractAirlineRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAirlineRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOAirline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOAirline> Get(int id)
		{
			Airline record = await this.GetById(id);

			return this.Mapper.AirlineMapEFToPOCO(record);
		}

		public async virtual Task<POCOAirline> Create(
			ApiAirlineModel model)
		{
			Airline record = new Airline();

			this.Mapper.AirlineMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Airline>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.AirlineMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiAirlineModel model)
		{
			Airline record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.AirlineMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Airline record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Airline>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOAirline>> Where(Expression<Func<Airline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAirline> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOAirline>> SearchLinqPOCO(Expression<Func<Airline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAirline> response = new List<POCOAirline>();
			List<Airline> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.AirlineMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Airline>> SearchLinqEF(Expression<Func<Airline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Airline.Id)} ASC";
			}
			return await this.Context.Set<Airline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Airline>();
		}

		private async Task<List<Airline>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Airline.Id)} ASC";
			}

			return await this.Context.Set<Airline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Airline>();
		}

		private async Task<Airline> GetById(int id)
		{
			List<Airline> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a9449fdc8eceafa1d32233698d56f53a</Hash>
</Codenesium>*/