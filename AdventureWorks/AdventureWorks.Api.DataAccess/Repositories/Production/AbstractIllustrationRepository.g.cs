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
		protected IDALIllustrationMapper Mapper { get; }

		public AbstractIllustrationRepository(
			IDALIllustrationMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOIllustration> Get(int illustrationID)
		{
			Illustration record = await this.GetById(illustrationID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOIllustration> Create(
			DTOIllustration dto)
		{
			Illustration record = new Illustration();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Illustration>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int illustrationID,
			DTOIllustration dto)
		{
			Illustration record = await this.GetById(illustrationID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{illustrationID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					illustrationID,
					dto,
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

		protected async Task<List<DTOIllustration>> Where(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOIllustration> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOIllustration>> SearchLinqDTO(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOIllustration> response = new List<DTOIllustration>();
			List<Illustration> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>47b937c0dc3a91f8294fa6c76255ab00</Hash>
</Codenesium>*/