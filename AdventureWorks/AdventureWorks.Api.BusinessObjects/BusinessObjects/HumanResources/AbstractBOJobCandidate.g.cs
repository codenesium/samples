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
		private IApiJobCandidateRequestModelValidator jobCandidateModelValidator;
		private IBOLJobCandidateMapper jobCandidateMapper;
		private ILogger logger;

		public AbstractBOJobCandidate(
			ILogger logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper jobCandidateMapper)
			: base()

		{
			this.jobCandidateRepository = jobCandidateRepository;
			this.jobCandidateModelValidator = jobCandidateModelValidator;
			this.jobCandidateMapper = jobCandidateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.jobCandidateRepository.All(skip, take, orderClause);

			return this.jobCandidateMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiJobCandidateResponseModel> Get(int jobCandidateID)
		{
			var record = await jobCandidateRepository.Get(jobCandidateID);

			return this.jobCandidateMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiJobCandidateResponseModel>> Create(
			ApiJobCandidateRequestModel model)
		{
			CreateResponse<ApiJobCandidateResponseModel> response = new CreateResponse<ApiJobCandidateResponseModel>(await this.jobCandidateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.jobCandidateMapper.MapModelToDTO(default (int), model);
				var record = await this.jobCandidateRepository.Create(dto);

				response.SetRecord(this.jobCandidateMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int jobCandidateID,
			ApiJobCandidateRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateUpdateAsync(jobCandidateID, model));

			if (response.Success)
			{
				var dto = this.jobCandidateMapper.MapModelToDTO(jobCandidateID, model);
				await this.jobCandidateRepository.Update(jobCandidateID, dto);
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

		public async Task<List<ApiJobCandidateResponseModel>> GetBusinessEntityID(Nullable<int> businessEntityID)
		{
			List<DTOJobCandidate> records = await this.jobCandidateRepository.GetBusinessEntityID(businessEntityID);

			return this.jobCandidateMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>ad2f3b6caf5b5df116484fa81d441a9a</Hash>
</Codenesium>*/