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
		private IJobCandidateModelValidator jobCandidateModelValidator;
		private ILogger logger;

		public AbstractBOJobCandidate(
			ILogger logger,
			IJobCandidateRepository jobCandidateRepository,
			IJobCandidateModelValidator jobCandidateModelValidator)

		{
			this.jobCandidateRepository = jobCandidateRepository;
			this.jobCandidateModelValidator = jobCandidateModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			JobCandidateModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.jobCandidateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.jobCandidateRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int jobCandidateID,
			JobCandidateModel model)
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

		public virtual POCOJobCandidate Get(int jobCandidateID)
		{
			return this.jobCandidateRepository.Get(jobCandidateID);
		}

		public virtual List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.jobCandidateRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>725d1d6f8e578ee132f9d5bfd4b4f4f9</Hash>
</Codenesium>*/