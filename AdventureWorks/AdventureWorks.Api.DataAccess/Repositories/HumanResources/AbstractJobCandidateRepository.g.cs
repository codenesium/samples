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
		protected IDALJobCandidateMapper Mapper { get; }

		public AbstractJobCandidateRepository(
			IDALJobCandidateMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOJobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOJobCandidate> Get(int jobCandidateID)
		{
			JobCandidate record = await this.GetById(jobCandidateID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOJobCandidate> Create(
			DTOJobCandidate dto)
		{
			JobCandidate record = new JobCandidate();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<JobCandidate>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int jobCandidateID,
			DTOJobCandidate dto)
		{
			JobCandidate record = await this.GetById(jobCandidateID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{jobCandidateID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					jobCandidateID,
					dto,
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

		public async Task<List<DTOJobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID)
		{
			var records = await this.SearchLinqDTO(x => x.BusinessEntityID == businessEntityID);

			return records;
		}

		protected async Task<List<DTOJobCandidate>> Where(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOJobCandidate> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOJobCandidate>> SearchLinqDTO(Expression<Func<JobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOJobCandidate> response = new List<DTOJobCandidate>();
			List<JobCandidate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>764f24932e8085f89ede58ea2a9e4281</Hash>
</Codenesium>*/