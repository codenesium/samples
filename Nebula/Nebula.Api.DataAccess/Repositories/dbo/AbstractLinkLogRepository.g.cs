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
	public abstract class AbstractLinkLogRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLinkLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLinkLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLinkLog> Get(int id)
		{
			LinkLog record = await this.GetById(id);

			return this.Mapper.LinkLogMapEFToPOCO(record);
		}

		public async virtual Task<POCOLinkLog> Create(
			ApiLinkLogModel model)
		{
			LinkLog record = new LinkLog();

			this.Mapper.LinkLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LinkLog>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LinkLogMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiLinkLogModel model)
		{
			LinkLog record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LinkLogMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			LinkLog record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LinkLog>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOLinkLog>> Where(Expression<Func<LinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLinkLog> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLinkLog>> SearchLinqPOCO(Expression<Func<LinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLinkLog> response = new List<POCOLinkLog>();
			List<LinkLog> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LinkLogMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<LinkLog>> SearchLinqEF(Expression<Func<LinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkLog.Id)} ASC";
			}
			return await this.Context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LinkLog>();
		}

		private async Task<List<LinkLog>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LinkLog.Id)} ASC";
			}

			return await this.Context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LinkLog>();
		}

		private async Task<LinkLog> GetById(int id)
		{
			List<LinkLog> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>36a7e82b6a112028ec2b88d8bfa2c803</Hash>
</Codenesium>*/