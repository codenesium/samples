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
	public abstract class AbstractIllustrationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractIllustrationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOIllustration> Get(int illustrationID)
		{
			Illustration record = await this.GetById(illustrationID);

			return this.Mapper.IllustrationMapEFToPOCO(record);
		}

		public async virtual Task<POCOIllustration> Create(
			ApiIllustrationModel model)
		{
			Illustration record = new Illustration();

			this.Mapper.IllustrationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Illustration>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.IllustrationMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int illustrationID,
			ApiIllustrationModel model)
		{
			Illustration record = await this.GetById(illustrationID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{illustrationID}");
			}
			else
			{
				this.Mapper.IllustrationMapModelToEF(
					illustrationID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int illustrationID)
		{
			Illustration record = await this.GetById(illustrationID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Illustration>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOIllustration>> Where(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOIllustration> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOIllustration>> SearchLinqPOCO(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOIllustration> response = new List<POCOIllustration>();
			List<Illustration> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.IllustrationMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Illustration>> SearchLinqEF(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Illustration.IllustrationID)} ASC";
			}
			return await this.Context.Set<Illustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Illustration>();
		}

		private async Task<List<Illustration>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Illustration.IllustrationID)} ASC";
			}

			return await this.Context.Set<Illustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Illustration>();
		}

		private async Task<Illustration> GetById(int illustrationID)
		{
			List<Illustration> records = await this.SearchLinqEF(x => x.IllustrationID == illustrationID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7b1df99bf3f1a55267be806a074fec9b</Hash>
</Codenesium>*/