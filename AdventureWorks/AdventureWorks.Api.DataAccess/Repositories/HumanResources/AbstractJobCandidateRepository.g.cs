using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractJobCandidateRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractJobCandidateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			JobCandidateModel model)
		{
			var record = new EFJobCandidate();

			this.mapper.JobCandidateMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFJobCandidate>().Add(record);
			this.context.SaveChanges();
			return record.JobCandidateID;
		}

		public virtual void Update(
			int jobCandidateID,
			JobCandidateModel model)
		{
			var record = this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{jobCandidateID}");
			}
			else
			{
				this.mapper.JobCandidateMapModelToEF(
					jobCandidateID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int jobCandidateID)
		{
			var record = this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFJobCandidate>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int jobCandidateID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID, response);
			return response;
		}

		public virtual POCOJobCandidate GetByIdDirect(int jobCandidateID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID, response);
			return response.JobCandidates.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOJobCandidate> GetWhereDirect(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.JobCandidates;
		}

		private void SearchLinqPOCO(Expression<Func<EFJobCandidate, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFJobCandidate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.JobCandidateMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFJobCandidate> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.JobCandidateMapEFToPOCO(x, response));
		}

		protected virtual List<EFJobCandidate> SearchLinqEF(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFJobCandidate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>b35e9c25c1af4683096442fa85bc39b0</Hash>
</Codenesium>*/