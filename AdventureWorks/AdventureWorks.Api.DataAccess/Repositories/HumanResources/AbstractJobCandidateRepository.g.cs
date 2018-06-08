using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractJobCandidateRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractJobCandidateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<JobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                public async Task<List<JobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID)
                {
                        var records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records;
                }

                protected async Task<List<JobCandidate>> Where(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<JobCandidate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
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
    <Hash>9fb78029939b096aa6e110b24160b105</Hash>
</Codenesium>*/