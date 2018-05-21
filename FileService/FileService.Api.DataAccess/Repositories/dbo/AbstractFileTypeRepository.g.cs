using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractFileTypeRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractFileTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOFileType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOFileType> Get(int id)
		{
			FileType record = await this.GetById(id);

			return this.Mapper.FileTypeMapEFToPOCO(record);
		}

		public async virtual Task<POCOFileType> Create(
			ApiFileTypeModel model)
		{
			FileType record = new FileType();

			this.Mapper.FileTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<FileType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.FileTypeMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiFileTypeModel model)
		{
			FileType record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.FileTypeMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			FileType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<FileType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOFileType>> Where(Expression<Func<FileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOFileType> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOFileType>> SearchLinqPOCO(Expression<Func<FileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOFileType> response = new List<POCOFileType>();
			List<FileType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.FileTypeMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<FileType>> SearchLinqEF(Expression<Func<FileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(FileType.Id)} ASC";
			}
			return await this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<FileType>();
		}

		private async Task<List<FileType>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(FileType.Id)} ASC";
			}

			return await this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<FileType>();
		}

		private async Task<FileType> GetById(int id)
		{
			List<FileType> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8ee0d4cc1f1abe21d464a8b431651571</Hash>
</Codenesium>*/