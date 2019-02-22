using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractJobCandidateService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IJobCandidateRepository JobCandidateRepository { get; private set; }

		protected IApiJobCandidateServerRequestModelValidator JobCandidateModelValidator { get; private set; }

		protected IDALJobCandidateMapper DalJobCandidateMapper { get; private set; }

		private ILogger logger;

		public AbstractJobCandidateService(
			ILogger logger,
			MediatR.IMediator mediator,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateServerRequestModelValidator jobCandidateModelValidator,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base()
		{
			this.JobCandidateRepository = jobCandidateRepository;
			this.JobCandidateModelValidator = jobCandidateModelValidator;
			this.DalJobCandidateMapper = dalJobCandidateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiJobCandidateServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<JobCandidate> records = await this.JobCandidateRepository.All(limit, offset, query);

			return this.DalJobCandidateMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiJobCandidateServerResponseModel> Get(int jobCandidateID)
		{
			JobCandidate record = await this.JobCandidateRepository.Get(jobCandidateID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalJobCandidateMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiJobCandidateServerResponseModel>> Create(
			ApiJobCandidateServerRequestModel model)
		{
			CreateResponse<ApiJobCandidateServerResponseModel> response = ValidationResponseFactory<ApiJobCandidateServerResponseModel>.CreateResponse(await this.JobCandidateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				JobCandidate record = this.DalJobCandidateMapper.MapModelToEntity(default(int), model);
				record = await this.JobCandidateRepository.Create(record);

				response.SetRecord(this.DalJobCandidateMapper.MapEntityToModel(record));
				await this.mediator.Publish(new JobCandidateCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiJobCandidateServerResponseModel>> Update(
			int jobCandidateID,
			ApiJobCandidateServerRequestModel model)
		{
			var validationResult = await this.JobCandidateModelValidator.ValidateUpdateAsync(jobCandidateID, model);

			if (validationResult.IsValid)
			{
				JobCandidate record = this.DalJobCandidateMapper.MapModelToEntity(jobCandidateID, model);
				await this.JobCandidateRepository.Update(record);

				record = await this.JobCandidateRepository.Get(jobCandidateID);

				ApiJobCandidateServerResponseModel apiModel = this.DalJobCandidateMapper.MapEntityToModel(record);
				await this.mediator.Publish(new JobCandidateUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiJobCandidateServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiJobCandidateServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int jobCandidateID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.JobCandidateModelValidator.ValidateDeleteAsync(jobCandidateID));

			if (response.Success)
			{
				await this.JobCandidateRepository.Delete(jobCandidateID);

				await this.mediator.Publish(new JobCandidateDeletedNotification(jobCandidateID));
			}

			return response;
		}

		public async virtual Task<List<ApiJobCandidateServerResponseModel>> ByBusinessEntityID(int? businessEntityID, int limit = 0, int offset = int.MaxValue)
		{
			List<JobCandidate> records = await this.JobCandidateRepository.ByBusinessEntityID(businessEntityID, limit, offset);

			return this.DalJobCandidateMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>2c27c895a70ba73784984ba455a2efeb</Hash>
</Codenesium>*/