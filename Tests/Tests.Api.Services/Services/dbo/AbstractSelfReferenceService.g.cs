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

		protected IBOLSelfReferenceMapper BolSelfReferenceMapper { get; private set; }

		protected IDALSelfReferenceMapper DalSelfReferenceMapper { get; private set; }

		private ILogger logger;

		public AbstractSelfReferenceService(
			ILogger logger,
			IMediator mediator,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceServerRequestModelValidator selfReferenceModelValidator,
			IBOLSelfReferenceMapper bolSelfReferenceMapper,
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base()
		{
			this.SelfReferenceRepository = selfReferenceRepository;
			this.SelfReferenceModelValidator = selfReferenceModelValidator;
			this.BolSelfReferenceMapper = bolSelfReferenceMapper;
			this.DalSelfReferenceMapper = dalSelfReferenceMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSelfReferenceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SelfReferenceRepository.All(limit, offset);

			return this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSelfReferenceServerResponseModel> Get(int id)
		{
			var record = await this.SelfReferenceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSelfReferenceServerResponseModel>> Create(
			ApiSelfReferenceServerRequestModel model)
		{
			CreateResponse<ApiSelfReferenceServerResponseModel> response = ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.CreateResponse(await this.SelfReferenceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSelfReferenceMapper.MapModelToBO(default(int), model);
				var record = await this.SelfReferenceRepository.Create(this.DalSelfReferenceMapper.MapBOToEF(bo));

				var businessObject = this.DalSelfReferenceMapper.MapEFToBO(record);
				response.SetRecord(this.BolSelfReferenceMapper.MapBOToModel(businessObject));
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
				var bo = this.BolSelfReferenceMapper.MapModelToBO(id, model);
				await this.SelfReferenceRepository.Update(this.DalSelfReferenceMapper.MapBOToEF(bo));

				var record = await this.SelfReferenceRepository.Get(id);

				var businessObject = this.DalSelfReferenceMapper.MapEFToBO(record);
				var apiModel = this.BolSelfReferenceMapper.MapBOToModel(businessObject);
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
	}
}

/*<Codenesium>
    <Hash>dc247ed7b78ef32dc0a3e26cc3eba987</Hash>
</Codenesium>*/