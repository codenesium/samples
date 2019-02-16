using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractSelfReferenceService : AbstractService
	{
		private IMediator mediator;

		protected ISelfReferenceRepository SelfReferenceRepository { get; private set; }

		protected IApiSelfReferenceServerRequestModelValidator SelfReferenceModelValidator { get; private set; }

		protected IDALSelfReferenceMapper DalSelfReferenceMapper { get; private set; }

		private ILogger logger;

		public AbstractSelfReferenceService(
			ILogger logger,
			IMediator mediator,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceServerRequestModelValidator selfReferenceModelValidator,
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base()
		{
			this.SelfReferenceRepository = selfReferenceRepository;
			this.SelfReferenceModelValidator = selfReferenceModelValidator;
			this.DalSelfReferenceMapper = dalSelfReferenceMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSelfReferenceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<SelfReference> records = await this.SelfReferenceRepository.All(limit, offset, query);

			return this.DalSelfReferenceMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSelfReferenceServerResponseModel> Get(int id)
		{
			SelfReference record = await this.SelfReferenceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSelfReferenceMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSelfReferenceServerResponseModel>> Create(
			ApiSelfReferenceServerRequestModel model)
		{
			CreateResponse<ApiSelfReferenceServerResponseModel> response = ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.CreateResponse(await this.SelfReferenceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SelfReference record = this.DalSelfReferenceMapper.MapModelToEntity(default(int), model);
				record = await this.SelfReferenceRepository.Create(record);

				response.SetRecord(this.DalSelfReferenceMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SelfReferenceCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSelfReferenceServerResponseModel>> Update(
			int id,
			ApiSelfReferenceServerRequestModel model)
		{
			var validationResult = await this.SelfReferenceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				SelfReference record = this.DalSelfReferenceMapper.MapModelToEntity(id, model);
				await this.SelfReferenceRepository.Update(record);

				record = await this.SelfReferenceRepository.Get(id);

				ApiSelfReferenceServerResponseModel apiModel = this.DalSelfReferenceMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SelfReferenceUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SelfReferenceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SelfReferenceRepository.Delete(id);

				await this.mediator.Publish(new SelfReferenceDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSelfReferenceServerResponseModel>> SelfReferencesBySelfReferenceId(int selfReferenceId, int limit = int.MaxValue, int offset = 0)
		{
			List<SelfReference> records = await this.SelfReferenceRepository.SelfReferencesBySelfReferenceId(selfReferenceId, limit, offset);

			return this.DalSelfReferenceMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSelfReferenceServerResponseModel>> SelfReferencesBySelfReferenceId2(int selfReferenceId2, int limit = int.MaxValue, int offset = 0)
		{
			List<SelfReference> records = await this.SelfReferenceRepository.SelfReferencesBySelfReferenceId2(selfReferenceId2, limit, offset);

			return this.DalSelfReferenceMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7d2ea53d8a95d493a763d513436599ca</Hash>
</Codenesium>*/