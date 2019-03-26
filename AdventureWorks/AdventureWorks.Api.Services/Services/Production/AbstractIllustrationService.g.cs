using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractIllustrationService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IIllustrationRepository IllustrationRepository { get; private set; }

		protected IApiIllustrationServerRequestModelValidator IllustrationModelValidator { get; private set; }

		protected IDALIllustrationMapper DalIllustrationMapper { get; private set; }

		private ILogger logger;

		public AbstractIllustrationService(
			ILogger logger,
			MediatR.IMediator mediator,
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
			List<Illustration> records = await this.IllustrationRepository.All(limit, offset, query);

			return this.DalIllustrationMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiIllustrationServerResponseModel> Get(int illustrationID)
		{
			Illustration record = await this.IllustrationRepository.Get(illustrationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalIllustrationMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiIllustrationServerResponseModel>> Create(
			ApiIllustrationServerRequestModel model)
		{
			CreateResponse<ApiIllustrationServerResponseModel> response = ValidationResponseFactory<ApiIllustrationServerResponseModel>.CreateResponse(await this.IllustrationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Illustration record = this.DalIllustrationMapper.MapModelToEntity(default(int), model);
				record = await this.IllustrationRepository.Create(record);

				response.SetRecord(this.DalIllustrationMapper.MapEntityToModel(record));
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
				Illustration record = this.DalIllustrationMapper.MapModelToEntity(illustrationID, model);
				await this.IllustrationRepository.Update(record);

				record = await this.IllustrationRepository.Get(illustrationID);

				ApiIllustrationServerResponseModel apiModel = this.DalIllustrationMapper.MapEntityToModel(record);
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
    <Hash>7ab111ddcb510dd0de1601597ee7a400</Hash>
</Codenesium>*/