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
		protected IObjectMapper Mapper { get; }

		public AbstractBucketRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOBucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOBucket> Get(int id)
		{
			Bucket record = await this.GetById(id);

			return this.Mapper.BucketMapEFToPOCO(record);
		}

		public async virtual Task<POCOBucket> Create(
			ApiBucketModel model)
		{
			Bucket record = new Bucket();

			this.Mapper.BucketMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Bucket>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.BucketMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiBucketModel model)
		{
			Bucket record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.BucketMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
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

		public async Task<POCOBucket> Name(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<POCOBucket> ExternalId(Guid externalId)
		{
			var records = await this.SearchLinqPOCO(x => x.ExternalId == externalId);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOBucket>> Where(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBucket> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOBucket>> SearchLinqPOCO(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBucket> response = new List<POCOBucket>();
			List<Bucket> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.BucketMapEFToPOCO(x)));
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
    <Hash>98f010c160670875e61463bc3c5a9874</Hash>
</Codenesium>*/