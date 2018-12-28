using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractJobCandidateService : AbstractService
	{
		private IMediator mediator;

		protected IJobCandidateRepository JobCandidateRepository { get; private set; }

		protected IApiJobCandidateServerRequestModelValidator JobCandidateModelValidator { get; private set; }

		protected IBOLJobCandidateMapper BolJobCandidateMapper { get; private set; }

		protected IDALJobCandidateMapper DalJobCandidateMapper { get; private set; }

		private ILogger logger;

		public AbstractJobCandidateService(
			ILogger logger,
			IMediator mediator,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateServerRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper bolJobCandidateMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base()
		{
			this.JobCandidateRepository = jobCandidateRepository;
			this.JobCandidateModelValidator = jobCandidateModelValidator;
			this.BolJobCandidateMapper = bolJobCandidateMapper;
			this.DalJobCandidateMapper = dalJobCandidateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiJobCandidateServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.JobCandidateRepository.All(limit, offset);

			return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiJobCandidateServerResponseModel> Get(int jobCandidateID)
		{
			var record = await this.JobCandidateRepository.Get(jobCandidateID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiJobCandidateServerResponseModel>> Create(
			ApiJobCandidateServerRequestModel model)
		{
			CreateResponse<ApiJobCandidateServerResponseModel> response = ValidationResponseFactory<ApiJobCandidateServerResponseModel>.CreateResponse(await this.JobCandidateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolJobCandidateMapper.MapModelToBO(default(int), model);
				var record = await this.JobCandidateRepository.Create(this.DalJobCandidateMapper.MapBOToEF(bo));

				var businessObject = this.DalJobCandidateMapper.MapEFToBO(record);
				response.SetRecord(this.BolJobCandidateMapper.MapBOToModel(businessObject));
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
				var bo = this.BolJobCandidateMapper.MapModelToBO(jobCandidateID, model);
				await this.JobCandidateRepository.Update(this.DalJobCandidateMapper.MapBOToEF(bo));

				var record = await this.JobCandidateRepository.Get(jobCandidateID);

				var businessObject = this.DalJobCandidateMapper.MapEFToBO(record);
				var apiModel = this.BolJobCandidateMapper.MapBOToModel(businessObject);
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

			return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a87ff17e1fa2a08f217bead9277423ec</Hash>
</Codenesium>*/