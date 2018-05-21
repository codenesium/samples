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
	public abstract class AbstractLinkStatusRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLinkStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLinkStatus> Get(int id)
		{
			LinkStatus record = await this.GetById(id);

			return this.Mapper.LinkStatusMapEFToPOCO(record);
		}

		public async virtual Task<POCOLinkStatus> Create(
			ApiLinkStatusModel model)
		{
			LinkStatus record = new LinkStatus();

			this.Mapper.LinkStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LinkStatus>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LinkStatusMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiLinkStatusModel model)
		{
			LinkStatus record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LinkStatusMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			LinkStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOLinkStatus> Name(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOLinkStatus>> Where(Expression<Func<LinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLinkStatus> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLinkStatus>> SearchLinqPOCO(Expression<Func<LinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLinkStatus> response = new List<POCOLinkStatus>();
			List<LinkStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LinkStatusMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<LinkStatus>> SearchLinqEF(Expression<Func<LinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkStatus.Id)} ASC";
			}
			return await this.Context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LinkStatus>();
		}

		private async Task<List<LinkStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkStatus.Id)} ASC";
			}

			return await this.Context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LinkStatus>();
		}

		private async Task<LinkStatus> GetById(int id)
		{
			List<LinkStatus> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ff316284b67a89160669bae799221a64</Hash>
</Codenesium>*/