using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractIllustrationService : AbstractService
	{
		private IMediator mediator;

		protected IIllustrationRepository IllustrationRepository { get; private set; }

		protected IApiIllustrationServerRequestModelValidator IllustrationModelValidator { get; private set; }

		protected IBOLIllustrationMapper BolIllustrationMapper { get; private set; }

		protected IDALIllustrationMapper DalIllustrationMapper { get; private set; }

		private ILogger logger;

		public AbstractIllustrationService(
			ILogger logger,
			IMediator mediator,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationServerRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper bolIllustrationMapper,
			IDALIllustrationMapper dalIllustrationMapper)
			: base()
		{
			this.IllustrationRepository = illustrationRepository;
			this.IllustrationModelValidator = illustrationModelValidator;
			this.BolIllustrationMapper = bolIllustrationMapper;
			this.DalIllustrationMapper = dalIllustrationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiIllustrationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.IllustrationRepository.All(limit, offset);

			return this.BolIllustrationMapper.MapBOToModel(this.DalIllustrationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiIllustrationServerResponseModel> Get(int illustrationID)
		{
			var record = await this.IllustrationRepository.Get(illustrationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolIllustrationMapper.MapBOToModel(this.DalIllustrationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiIllustrationServerResponseModel>> Create(
			ApiIllustrationServerRequestModel model)
		{
			CreateResponse<ApiIllustrationServerResponseModel> response = ValidationResponseFactory<ApiIllustrationServerResponseModel>.CreateResponse(await this.IllustrationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolIllustrationMapper.MapModelToBO(default(int), model);
				var record = await this.IllustrationRepository.Create(this.DalIllustrationMapper.MapBOToEF(bo));

				var businessObject = this.DalIllustrationMapper.MapEFToBO(record);
				response.SetRecord(this.BolIllustrationMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new IllustrationCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiIllustrationServerResponseModel>> Update(
			int illustrationID,
			ApiIllustrationServerRequestModel model)
		{
			var validationResult = await this.IllustrationModelValidator.ValidateUpdateAsync(illustrationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolIllustrationMapper.MapModelToBO(illustrationID, model);
				await this.IllustrationRepository.Update(this.DalIllustrationMapper.MapBOToEF(bo));

				var record = await this.IllustrationRepository.Get(illustrationID);

				var businessObject = this.DalIllustrationMapper.MapEFToBO(record);
				var apiModel = this.BolIllustrationMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new IllustrationUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiIllustrationServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiIllustrationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int illustrationID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.IllustrationModelValidator.ValidateDeleteAsync(illustrationID));

			if (response.Success)
			{
				await this.IllustrationRepository.Delete(illustrationID);

				await this.mediator.Publish(new IllustrationDeletedNotification(illustrationID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>79ff4fb63d9251e19bc5bdef29b0e180</Hash>
</Codenesium>*/