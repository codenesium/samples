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
		protected IDALLinkMapper Mapper { get; }

		public AbstractLinkRepository(
			IDALLinkMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOLink>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOLink> Get(int id)
		{
			Link record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOLink> Create(
			DTOLink dto)
		{
			Link record = new Link();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Link>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTOLink dto)
		{
			Link record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					id,
					dto,
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

		public async Task<DTOLink> GetExternalId(Guid externalId)
		{
			var records = await this.SearchLinqDTO(x => x.ExternalId == externalId);

			return records.FirstOrDefault();
		}
		public async Task<List<DTOLink>> GetChainId(int chainId)
		{
			var records = await this.SearchLinqDTO(x => x.ChainId == chainId);

			return records;
		}

		protected async Task<List<DTOLink>> Where(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOLink> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOLink>> SearchLinqDTO(Expression<Func<Link, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOLink> response = new List<DTOLink>();
			List<Link> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>178e41f99c8496fae96d90515e3b846c</Hash>
</Codenesium>*/