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
	public abstract class AbstractStudioRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStudioRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOStudio>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOStudio> Get(int id)
		{
			Studio record = await this.GetById(id);

			return this.Mapper.StudioMapEFToPOCO(record);
		}

		public async virtual Task<POCOStudio> Create(
			ApiStudioModel model)
		{
			Studio record = new Studio();

			this.Mapper.StudioMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Studio>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.StudioMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiStudioModel model)
		{
			Studio record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.StudioMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Studio record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Studio>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOStudio>> Where(Expression<Func<Studio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStudio> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOStudio>> SearchLinqPOCO(Expression<Func<Studio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStudio> response = new List<POCOStudio>();
			List<Studio> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.StudioMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Studio>> SearchLinqEF(Expression<Func<Studio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Studio.Id)} ASC";
			}
			return await this.Context.Set<Studio>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Studio>();
		}

		private async Task<List<Studio>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Studio.Id)} ASC";
			}

			return await this.Context.Set<Studio>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Studio>();
		}

		private async Task<Studio> GetById(int id)
		{
			List<Studio> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4032c373ea256cf93175dd4a296f9240</Hash>
</Codenesium>*/