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
	public abstract class AbstractBOJobCandidate: AbstractBOManager
	{
		private IJobCandidateRepository jobCandidateRepository;
		private IApiJobCandidateModelValidator jobCandidateModelValidator;
		private ILogger logger;

		public AbstractBOJobCandidate(
			ILogger logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateModelValidator jobCandidateModelValidator)
			: base()

		{
			this.jobCandidateRepository = jobCandidateRepository;
			this.jobCandidateModelValidator = jobCandidateModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOJobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.jobCandidateRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOJobCandidate> Get(int jobCandidateID)
		{
			return this.jobCandidateRepository.Get(jobCandidateID);
		}

		public virtual async Task<CreateResponse<POCOJobCandidate>> Create(
			ApiJobCandidateModel model)
		{
			CreateResponse<POCOJobCandidate> response = new CreateResponse<POCOJobCandidate>(await this.jobCandidateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOJobCandidate record = await this.jobCandidateRepository.Create(model);

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
				await this.jobCandidateRepository.Update(jobCandidateID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int jobCandidateID)
		{
			ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateDeleteAsync(jobCandidateID));

			if (response.Success)
			{
				await this.jobCandidateRepository.Delete(jobCandidateID);
			}
			return response;
		}

		public async Task<List<POCOJobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID)
		{
			return await this.jobCandidateRepository.GetBusinessEntityID(businessEntityID);
		}
	}
}

/*<Codenesium>
    <Hash>4a998f2958dbe4c55a3f814f74bb7d39</Hash>
</Codenesium>*/