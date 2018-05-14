using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractBucketRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBucketRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOBucket Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOBucket Create(
			ApiBucketModel model)
		{
			Bucket record = new Bucket();

			this.Mapper.BucketMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Bucket>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.BucketMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiBucketModel model)
		{
			Bucket record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Bucket record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Bucket>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOBucket Name(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		public POCOBucket ExternalId(Guid externalId)
		{
			return this.SearchLinqPOCO(x => x.ExternalId == externalId).FirstOrDefault();
		}

		protected List<POCOBucket> Where(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOBucket> SearchLinqPOCO(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBucket> response = new List<POCOBucket>();
			List<Bucket> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.BucketMapEFToPOCO(x)));
			return response;
		}

		private List<Bucket> SearchLinqEF(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Bucket.Id)} ASC";
			}
			return this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Bucket>();
		}

		private List<Bucket> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Bucket.Id)} ASC";
			}

			return this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Bucket>();
		}
	}
}

/*<Codenesium>
    <Hash>179125bd0f31e92882ec498bfcb05bdf</Hash>
</Codenesium>*/