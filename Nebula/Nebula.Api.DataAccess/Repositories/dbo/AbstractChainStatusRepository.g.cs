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
	public abstract class AbstractChainStatusRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractChainStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOChainStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOChainStatus> Get(int id)
		{
			ChainStatus record = await this.GetById(id);

			return this.Mapper.ChainStatusMapEFToPOCO(record);
		}

		public async virtual Task<POCOChainStatus> Create(
			ApiChainStatusModel model)
		{
			ChainStatus record = new ChainStatus();

			this.Mapper.ChainStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ChainStatus>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ChainStatusMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiChainStatusModel model)
		{
			ChainStatus record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.ChainStatusMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			ChainStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ChainStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOChainStatus> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOChainStatus>> Where(Expression<Func<ChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOChainStatus> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOChainStatus>> SearchLinqPOCO(Expression<Func<ChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOChainStatus> response = new List<POCOChainStatus>();
			List<ChainStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ChainStatusMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ChainStatus>> SearchLinqEF(Expression<Func<ChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ChainStatus.Id)} ASC";
			}
			return await this.Context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ChainStatus>();
		}

		private async Task<List<ChainStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ChainStatus.Id)} ASC";
			}

			return await this.Context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ChainStatus>();
		}

		private async Task<ChainStatus> GetById(int id)
		{
			List<ChainStatus> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>26324f0ca33ad91eb3fdff8b30a41985</Hash>
</Codenesium>*/