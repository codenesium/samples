using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCultureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCulture> Get(string cultureID)
		{
			Culture record = await this.GetById(cultureID);

			return this.Mapper.CultureMapEFToPOCO(record);
		}

		public async virtual Task<POCOCulture> Create(
			ApiCultureModel model)
		{
			Culture record = new Culture();

			this.Mapper.CultureMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<Culture>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CultureMapEFToPOCO(record);
		}

		public async virtual Task Update(
			string cultureID,
			ApiCultureModel model)
		{
			Culture record = await this.GetById(cultureID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{cultureID}");
			}
			else
			{
				this.Mapper.CultureMapModelToEF(
					cultureID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			string cultureID)
		{
			Culture record = await this.GetById(cultureID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Culture>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOCulture> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOCulture>> Where(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCulture> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCulture>> SearchLinqPOCO(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCulture> response = new List<POCOCulture>();
			List<Culture> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CultureMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Culture>> SearchLinqEF(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}
			return await this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Culture>();
		}

		private async Task<List<Culture>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}

			return await this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Culture>();
		}

		private async Task<Culture> GetById(string cultureID)
		{
			List<Culture> records = await this.SearchLinqEF(x => x.CultureID == cultureID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8b446f255fa2b684bc89f6a62c403a5e</Hash>
</Codenesium>*/