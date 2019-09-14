using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class BadgeService : AbstractService, IBadgeService
	{
		private MediatR.IMediator mediator;

		protected IBadgeRepository BadgeRepository { get; private set; }

		protected IApiBadgeServerRequestModelValidator BadgeModelValidator { get; private set; }

		protected IDALBadgeMapper DalBadgeMapper { get; private set; }

		private ILogger logger;

		public BadgeService(
			ILogger<IBadgeService> logger,
			MediatR.IMediator mediator,
			IBadgeRepository badgeRepository,
			IApiBadgeServerRequestModelValidator badgeModelValidator,
			IDALBadgeMapper dalBadgeMapper)
			: base()
		{
			this.BadgeRepository = badgeRepository;
			this.BadgeModelValidator = badgeModelValidator;
			this.DalBadgeMapper = dalBadgeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBadgeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Badge> records = await this.BadgeRepository.All(limit, offset, query);

			return this.DalBadgeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiBadgeServerResponseModel> Get(int id)
		{
			Badge record = await this.BadgeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalBadgeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiBadgeServerResponseModel>> Create(
			ApiBadgeServerRequestModel model)
		{
			CreateResponse<ApiBadgeServerResponseModel> response = ValidationResponseFactory<ApiBadgeServerResponseModel>.CreateResponse(await this.BadgeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Badge record = this.DalBadgeMapper.MapModelToEntity(default(int), model);
				record = await this.BadgeRepository.Create(record);

				response.SetRecord(this.DalBadgeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new BadgeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBadgeServerResponseModel>> Update(
			int id,
			ApiBadgeServerRequestModel model)
		{
			var validationResult = await this.BadgeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Badge record = this.DalBadgeMapper.MapModelToEntity(id, model);
				await this.BadgeRepository.Update(record);

				record = await this.BadgeRepository.Get(id);

				ApiBadgeServerResponseModel apiModel = this.DalBadgeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new BadgeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiBadgeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiBadgeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.BadgeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.BadgeRepository.Delete(id);

				await this.mediator.Publish(new BadgeDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiBadgeServerResponseModel>> ByUserId(int userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Badge> records = await this.BadgeRepository.ByUserId(userId, limit, offset);

			return this.DalBadgeMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>3ab7f1987db90f37e5a066702dafb0e1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/