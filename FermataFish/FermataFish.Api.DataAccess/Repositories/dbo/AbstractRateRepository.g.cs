using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractRateRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCORate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCORate> Get(int id)
		{
			Rate record = await this.GetById(id);

			return this.Mapper.RateMapEFToPOCO(record);
		}

		public async virtual Task<POCORate> Create(
			ApiRateModel model)
		{
			Rate record = new Rate();

			this.Mapper.RateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Rate>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.RateMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiRateModel model)
		{
			Rate record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.RateMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Rate record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Rate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCORate>> Where(Expression<Func<Rate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCORate> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCORate>> SearchLinqPOCO(Expression<Func<Rate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCORate> response = new List<POCORate>();
			List<Rate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.RateMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Rate>> SearchLinqEF(Expression<Func<Rate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Rate.Id)} ASC";
			}
			return await this.Context.Set<Rate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Rate>();
		}

		private async Task<List<Rate>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Rate.Id)} ASC";
			}

			return await this.Context.Set<Rate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Rate>();
		}

		private async Task<Rate> GetById(int id)
		{
			List<Rate> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a489bdd0ae24c746a5b874a0f7db5370</Hash>
</Codenesium>*/