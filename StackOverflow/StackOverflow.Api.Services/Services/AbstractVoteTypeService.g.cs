using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractVoteTypeService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVoteTypeRepository VoteTypeRepository { get; private set; }

		protected IApiVoteTypeServerRequestModelValidator VoteTypeModelValidator { get; private set; }

		protected IDALVoteTypeMapper DalVoteTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteTypeService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVoteTypeRepository voteTypeRepository,
			IApiVoteTypeServerRequestModelValidator voteTypeModelValidator,
			IDALVoteTypeMapper dalVoteTypeMapper)
			: base()
		{
			this.VoteTypeRepository = voteTypeRepository;
			this.VoteTypeModelValidator = voteTypeModelValidator;
			this.DalVoteTypeMapper = dalVoteTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVoteTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VoteType> records = await this.VoteTypeRepository.All(limit, offset, query);

			return this.DalVoteTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVoteTypeServerResponseModel> Get(int id)
		{
			VoteType record = await this.VoteTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVoteTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVoteTypeServerResponseModel>> Create(
			ApiVoteTypeServerRequestModel model)
		{
			CreateResponse<ApiVoteTypeServerResponseModel> response = ValidationResponseFactory<ApiVoteTypeServerResponseModel>.CreateResponse(await this.VoteTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VoteType record = this.DalVoteTypeMapper.MapModelToEntity(default(int), model);
				record = await this.VoteTypeRepository.Create(record);

				response.SetRecord(this.DalVoteTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VoteTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteTypeServerResponseModel>> Update(
			int id,
			ApiVoteTypeServerRequestModel model)
		{
			var validationResult = await this.VoteTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				VoteType record = this.DalVoteTypeMapper.MapModelToEntity(id, model);
				await this.VoteTypeRepository.Update(record);

				record = await this.VoteTypeRepository.Get(id);

				ApiVoteTypeServerResponseModel apiModel = this.DalVoteTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VoteTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVoteTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVoteTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VoteTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VoteTypeRepository.Delete(id);

				await this.mediator.Publish(new VoteTypeDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b798234a2ff7efd6a348b686e55b1de7</Hash>
</Codenesium>*/