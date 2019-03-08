using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBadgesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IBadgesRepository BadgesRepository { get; private set; }

		protected IApiBadgesServerRequestModelValidator BadgesModelValidator { get; private set; }

		protected IDALBadgesMapper DalBadgesMapper { get; private set; }

		private ILogger logger;

		public AbstractBadgesService(
			ILogger logger,
			MediatR.IMediator mediator,
			IBadgesRepository badgesRepository,
			IApiBadgesServerRequestModelValidator badgesModelValidator,
			IDALBadgesMapper dalBadgesMapper)
			: base()
		{
			this.BadgesRepository = badgesRepository;
			this.BadgesModelValidator = badgesModelValidator;
			this.DalBadgesMapper = dalBadgesMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBadgesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Badges> records = await this.BadgesRepository.All(limit, offset, query);

			return this.DalBadgesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiBadgesServerResponseModel> Get(int id)
		{
			Badges record = await this.BadgesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalBadgesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiBadgesServerResponseModel>> Create(
			ApiBadgesServerRequestModel model)
		{
			CreateResponse<ApiBadgesServerResponseModel> response = ValidationResponseFactory<ApiBadgesServerResponseModel>.CreateResponse(await this.BadgesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Badges record = this.DalBadgesMapper.MapModelToEntity(default(int), model);
				record = await this.BadgesRepository.Create(record);

				response.SetRecord(this.DalBadgesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new BadgesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBadgesServerResponseModel>> Update(
			int id,
			ApiBadgesServerRequestModel model)
		{
			var validationResult = await this.BadgesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Badges record = this.DalBadgesMapper.MapModelToEntity(id, model);
				await this.BadgesRepository.Update(record);

				record = await this.BadgesRepository.Get(id);

				ApiBadgesServerResponseModel apiModel = this.DalBadgesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new BadgesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiBadgesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiBadgesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.BadgesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.BadgesRepository.Delete(id);

				await this.mediator.Publish(new BadgesDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiBadgesServerResponseModel>> ByUserId(int userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Badges> records = await this.BadgesRepository.ByUserId(userId, limit, offset);

			return this.DalBadgesMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>65c5e45d37259ff2d9101707a373f54f</Hash>
</Codenesium>*/