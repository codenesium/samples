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
	public abstract class AbstractJobCandidateRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractJobCandidateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOJobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOJobCandidate> Get(int jobCandidateID)
		{
			JobCandidate record = await this.GetById(jobCandidateID);

			return this.Mapper.JobCandidateMapEFToPOCO(record);
		}

		public async virtual Task<POCOJobCandidate> Create(
			ApiJobCandidateModel model)
		{
			JobCandidate record = new JobCandidate();

			this.Mapper.JobCandidateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<JobCandidate>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.JobCandidateMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int jobCandidateID,
			ApiJobCandidateModel model)
		{
			JobCandidate record = await this.GetById(jobCandidateID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{jobCandidateID}");
			}
			else
			{
				this.Mapper.JobCandidateMapModelToEF(
					jobCandidateID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int jobCandidateID)
		{
			JobCandidate record = await this.GetById(jobCandidateID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<JobCandidate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOJobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID)
		{
			var records = await this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);

			return records;
		}

		protected async Task<List<POCOJobCandidate>> Where(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOJobCandidate> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOJobCandidate>> SearchLinqPOCO(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOJobCandidate> response = new List<POCOJobCandidate>();
			List<JobCandidate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.JobCandidateMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<JobCandidate>> SearchLinqEF(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(JobCandidate.JobCandidateID)} ASC";
			}
			return await this.Context.Set<JobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<JobCandidate>();
		}

		private async Task<List<JobCandidate>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(JobCandidate.JobCandidateID)} ASC";
			}

			return await this.Context.Set<JobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<JobCandidate>();
		}

		private async Task<JobCandidate> GetById(int jobCandidateID)
		{
			List<JobCandidate> records = await this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6d6c95177e37a7159a747c63825a90a3</Hash>
</Codenesium>*/