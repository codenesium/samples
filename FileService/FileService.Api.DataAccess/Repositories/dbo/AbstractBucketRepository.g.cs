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
	public abstract class AbstractBucketRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALBucketMapper Mapper { get; }

		public AbstractBucketRepository(
			IDALBucketMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOBucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOBucket> Get(int id)
		{
			Bucket record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOBucket> Create(
			DTOBucket dto)
		{
			Bucket record = new Bucket();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Bucket>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTOBucket dto)
		{
			Bucket record = await this.GetById(id);

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
			Bucket record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Bucket>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOBucket> GetExternalId(Guid externalId)
		{
			var records = await this.SearchLinqDTO(x => x.ExternalId == externalId);

			return records.FirstOrDefault();
		}
		public async Task<DTOBucket> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOBucket>> Where(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBucket> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOBucket>> SearchLinqDTO(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBucket> response = new List<DTOBucket>();
			List<Bucket> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<Bucket>> SearchLinqEF(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Bucket.Id)} ASC";
			}
			return await this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Bucket>();
		}

		private async Task<List<Bucket>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Bucket.Id)} ASC";
			}

			return await this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Bucket>();
		}

		private async Task<Bucket> GetById(int id)
		{
			List<Bucket> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d8270d2d7f587d550754d83582e96319</Hash>
</Codenesium>*/