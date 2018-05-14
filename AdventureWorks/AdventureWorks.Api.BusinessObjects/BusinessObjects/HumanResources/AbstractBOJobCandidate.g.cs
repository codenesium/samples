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
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOJobCandidate
	{
		private IJobCandidateRepository jobCandidateRepository;
		private IApiJobCandidateModelValidator jobCandidateModelValidator;
		private ILogger logger;

		public AbstractBOJobCandidate(
			ILogger logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateModelValidator jobCandidateModelValidator)

		{
			this.jobCandidateRepository = jobCandidateRepository;
			this.jobCandidateModelValidator = jobCandidateModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.jobCandidateRepository.All(skip, take, orderClause);
		}

		public virtual POCOJobCandidate Get(int jobCandidateID)
		{
			return this.jobCandidateRepository.Get(jobCandidateID);
		}

		public virtual async Task<CreateResponse<POCOJobCandidate>> Create(
			ApiJobCandidateModel model)
		{
			CreateResponse<POCOJobCandidate> response = new CreateResponse<POCOJobCandidate>(await this.jobCandidateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOJobCandidate record = this.jobCandidateRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int jobCandidateID,
			ApiJobCandidateModel model)
		{
			ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateUpdateAsync(jobCandidateID, model));

			if (response.Success)
			{
				this.jobCandidateRepository.Update(jobCandidateID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int jobCandidateID)
		{
			ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateDeleteAsync(jobCandidateID));

			if (response.Success)
			{
				this.jobCandidateRepository.Delete(jobCandidateID);
			}
			return response;
		}

		public List<POCOJobCandidate> GetBusinessEntityID(Nullable<int> businessEntityID)
		{
			return this.jobCandidateRepository.GetBusinessEntityID(businessEntityID);
		}
	}
}

/*<Codenesium>
    <Hash>598ce62efd987b8e5ffc8e1e08a04000</Hash>
</Codenesium>*/