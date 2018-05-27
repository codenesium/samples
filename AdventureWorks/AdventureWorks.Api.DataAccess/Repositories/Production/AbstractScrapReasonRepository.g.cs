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
	public abstract class AbstractScrapReasonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALScrapReasonMapper Mapper { get; }

		public AbstractScrapReasonRepository(
			IDALScrapReasonMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOScrapReason> Get(short scrapReasonID)
		{
			ScrapReason record = await this.GetById(scrapReasonID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOScrapReason> Create(
			DTOScrapReason dto)
		{
			ScrapReason record = new ScrapReason();

			this.Mapper.MapDTOToEF(
				default (short),
				dto,
				record);

			this.Context.Set<ScrapReason>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			short scrapReasonID,
			DTOScrapReason dto)
		{
			ScrapReason record = await this.GetById(scrapReasonID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{scrapReasonID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					scrapReasonID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			short scrapReasonID)
		{
			ScrapReason record = await this.GetById(scrapReasonID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ScrapReason>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOScrapReason> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOScrapReason>> Where(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOScrapReason> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOScrapReason>> SearchLinqDTO(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOScrapReason> response = new List<DTOScrapReason>();
			List<ScrapReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ScrapReason>> SearchLinqEF(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
			}
			return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ScrapReason>();
		}

		private async Task<List<ScrapReason>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
			}

			return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ScrapReason>();
		}

		private async Task<ScrapReason> GetById(short scrapReasonID)
		{
			List<ScrapReason> records = await this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6b36840e3c30cb4563dec927fffeba27</Hash>
</Codenesium>*/