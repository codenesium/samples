using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractJobCandidateRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractJobCandidateRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<JobCandidate>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BusinessEntityID == query.ToNullableInt() ||
				                  x.JobCandidateID == query.ToInt() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Resume.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<JobCandidate> Get(int jobCandidateID)
		{
			return await this.GetById(jobCandidateID);
		}

		public async virtual Task<JobCandidate> Create(JobCandidate item)
		{
			this.Context.Set<JobCandidate>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(JobCandidate item)
		{
			var entity = this.Context.Set<JobCandidate>().Local.FirstOrDefault(x => x.JobCandidateID == item.JobCandidateID);
			if (entity == null)
			{
				this.Context.Set<JobCandidate>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
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

		// Non-unique constraint IX_JobCandidate_BusinessEntityID.
		public async virtual Task<List<JobCandidate>> ByBusinessEntityID(int? businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.BusinessEntityID == businessEntityID, limit, offset);
		}

		protected async Task<List<JobCandidate>> Where(
			Expression<Func<JobCandidate, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<JobCandidate, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.JobCandidateID;
			}

			return await this.Context.Set<JobCandidate>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<JobCandidate>();
		}

		private async Task<JobCandidate> GetById(int jobCandidateID)
		{
			List<JobCandidate> records = await this.Where(x => x.JobCandidateID == jobCandidateID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bcb2033cff331c71a43f1c0eaa18fe6d</Hash>
</Codenesium>*/