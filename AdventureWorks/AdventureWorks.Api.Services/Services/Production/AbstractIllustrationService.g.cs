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

		protected IDALIllustrationMapper DalIllustrationMapper { get; private set; }

		private ILogger logger;

		public AbstractIllustrationService(
			ILogger logger,
			IMediator mediator,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationServerRequestModelValidator illustrationModelValidator,
			IDALIllustrationMapper dalIllustrationMapper)
			: base()
		{
			this.IllustrationRepository = illustrationRepository;
			this.IllustrationModelValidator = illustrationModelValidator;
			this.DalIllustrationMapper = dalIllustrationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiIllustrationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.IllustrationRepository.All(limit, offset, query);

			return this.DalIllustrationMapper.MapBOToModel(records);
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
				return this.DalIllustrationMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiIllustrationServerResponseModel>> Create(
			ApiIllustrationServerRequestModel model)
		{
			CreateResponse<ApiIllustrationServerResponseModel> response = ValidationResponseFactory<ApiIllustrationServerResponseModel>.CreateResponse(await this.IllustrationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalIllustrationMapper.MapModelToBO(default(int), model);
				var record = await this.IllustrationRepository.Create(bo);

				response.SetRecord(this.DalIllustrationMapper.MapBOToModel(record));
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
				var bo = this.DalIllustrationMapper.MapModelToBO(illustrationID, model);
				await this.IllustrationRepository.Update(bo);

				var record = await this.IllustrationRepository.Get(illustrationID);

				var apiModel = this.DalIllustrationMapper.MapBOToModel(record);
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
    <Hash>c851f063e6b3bedb327a07a414360420</Hash>
</Codenesium>*/