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
	public abstract class AbstractCultureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALCultureMapper Mapper { get; }

		public AbstractCultureRepository(
			IDALCultureMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOCulture> Get(string cultureID)
		{
			Culture record = await this.GetById(cultureID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOCulture> Create(
			DTOCulture dto)
		{
			Culture record = new Culture();

			this.Mapper.MapDTOToEF(
				default (string),
				dto,
				record);

			this.Context.Set<Culture>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			string cultureID,
			DTOCulture dto)
		{
			Culture record = await this.GetById(cultureID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{cultureID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					cultureID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			string cultureID)
		{
			Culture record = await this.GetById(cultureID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Culture>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOCulture> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOCulture>> Where(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCulture> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOCulture>> SearchLinqDTO(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCulture> response = new List<DTOCulture>();
			List<Culture> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<Culture>> SearchLinqEF(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}
			return await this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Culture>();
		}

		private async Task<List<Culture>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}

			return await this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Culture>();
		}

		private async Task<Culture> GetById(string cultureID)
		{
			List<Culture> records = await this.SearchLinqEF(x => x.CultureID == cultureID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7fd2f5ef77b8cedbe5677b6d8856c39f</Hash>
</Codenesium>*/