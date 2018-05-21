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
	public abstract class AbstractLinkRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLinkRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLink>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLink> Get(int id)
		{
			Link record = await this.GetById(id);

			return this.Mapper.LinkMapEFToPOCO(record);
		}

		public async virtual Task<POCOLink> Create(
			ApiLinkModel model)
		{
			Link record = new Link();

			this.Mapper.LinkMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Link>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LinkMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiLinkModel model)
		{
			Link record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LinkMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Link record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Link>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOLink> GetExternalId(Guid externalId)
		{
			var records = await this.SearchLinqPOCO(x => x.ExternalId == externalId);

			return records.FirstOrDefault();
		}
		public async Task<List<POCOLink>> GetChainId(int chainId)
		{
			var records = await this.SearchLinqPOCO(x => x.ChainId == chainId);

			return records;
		}

		protected async Task<List<POCOLink>> Where(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLink> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLink>> SearchLinqPOCO(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLink> response = new List<POCOLink>();
			List<Link> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LinkMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Link>> SearchLinqEF(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Link.Id)} ASC";
			}
			return await this.Context.Set<Link>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Link>();
		}

		private async Task<List<Link>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Link.Id)} ASC";
			}

			return await this.Context.Set<Link>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Link>();
		}

		private async Task<Link> GetById(int id)
		{
			List<Link> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>06701082ef2d89808052a326a2af4007</Hash>
</Codenesium>*/