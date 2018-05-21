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
	public abstract class AbstractCountryRequirementRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRequirementRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCountryRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCountryRequirement> Get(int id)
		{
			CountryRequirement record = await this.GetById(id);

			return this.Mapper.CountryRequirementMapEFToPOCO(record);
		}

		public async virtual Task<POCOCountryRequirement> Create(
			ApiCountryRequirementModel model)
		{
			CountryRequirement record = new CountryRequirement();

			this.Mapper.CountryRequirementMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<CountryRequirement>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CountryRequirementMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiCountryRequirementModel model)
		{
			CountryRequirement record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.CountryRequirementMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			CountryRequirement record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRequirement>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOCountryRequirement>> Where(Expression<Func<CountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRequirement> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCountryRequirement>> SearchLinqPOCO(Expression<Func<CountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRequirement> response = new List<POCOCountryRequirement>();
			List<CountryRequirement> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CountryRequirementMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<CountryRequirement>> SearchLinqEF(Expression<Func<CountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRequirement.Id)} ASC";
			}
			return await this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRequirement>();
		}

		private async Task<List<CountryRequirement>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRequirement.Id)} ASC";
			}

			return await this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRequirement>();
		}

		private async Task<CountryRequirement> GetById(int id)
		{
			List<CountryRequirement> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c7888daee59001749409a96412b2d785</Hash>
</Codenesium>*/