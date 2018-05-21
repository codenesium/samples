using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractChainRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractChainRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOChain>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOChain> Get(int id)
		{
			Chain record = await this.GetById(id);

			return this.Mapper.ChainMapEFToPOCO(record);
		}

		public async virtual Task<POCOChain> Create(
			ApiChainModel model)
		{
			Chain record = new Chain();

			this.Mapper.ChainMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Chain>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ChainMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiChainModel model)
		{
			Chain record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ChainMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Chain record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Chain>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOChain> ExternalId(Guid externalId)
		{
			var records = await this.SearchLinqPOCO(x => x.ExternalId == externalId);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOChain>> Where(Expression<Func<Chain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOChain> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOChain>> SearchLinqPOCO(Expression<Func<Chain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOChain> response = new List<POCOChain>();
			List<Chain> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ChainMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Chain>> SearchLinqEF(Expression<Func<Chain, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Chain.Id)} ASC";
			}
			return await this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Chain>();
		}

		private async Task<List<Chain>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Chain.Id)} ASC";
			}

			return await this.Context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Chain>();
		}

		private async Task<Chain> GetById(int id)
		{
			List<Chain> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5f1b485c4ad27e2c74a131412e04411c</Hash>
</Codenesium>*/