using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractVoteService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVoteRepository VoteRepository { get; private set; }

		protected IApiVoteServerRequestModelValidator VoteModelValidator { get; private set; }

		protected IDALVoteMapper DalVoteMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVoteRepository voteRepository,
			IApiVoteServerRequestModelValidator voteModelValidator,
			IDALVoteMapper dalVoteMapper)
			: base()
		{
			this.VoteRepository = voteRepository;
			this.VoteModelValidator = voteModelValidator;
			this.DalVoteMapper = dalVoteMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVoteServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Vote> records = await this.VoteRepository.All(limit, offset, query);

			return this.DalVoteMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVoteServerResponseModel> Get(int id)
		{
			Vote record = await this.VoteRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVoteMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVoteServerResponseModel>> Create(
			ApiVoteServerRequestModel model)
		{
			CreateResponse<ApiVoteServerResponseModel> response = ValidationResponseFactory<ApiVoteServerResponseModel>.CreateResponse(await this.VoteModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Vote record = this.DalVoteMapper.MapModelToEntity(default(int), model);
				record = await this.VoteRepository.Create(record);

				response.SetRecord(this.DalVoteMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VoteCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteServerResponseModel>> Update(
			int id,
			ApiVoteServerRequestModel model)
		{
			var validationResult = await this.VoteModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Vote record = this.DalVoteMapper.MapModelToEntity(id, model);
				await this.VoteRepository.Update(record);

				record = await this.VoteRepository.Get(id);

				ApiVoteServerResponseModel apiModel = this.DalVoteMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VoteUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVoteServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVoteServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VoteRepository.Delete(id);

				await this.mediator.Publish(new VoteDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVoteServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Vote> records = await this.VoteRepository.ByUserId(userId, limit, offset);

			return this.DalVoteMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVoteServerResponseModel>> ByPostId(int postId, int limit = 0, int offset = int.MaxValue)
		{
			List<Vote> records = await this.VoteRepository.ByPostId(postId, limit, offset);

			return this.DalVoteMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVoteServerResponseModel>> ByVoteTypeId(int voteTypeId, int limit = 0, int offset = int.MaxValue)
		{
			List<Vote> records = await this.VoteRepository.ByVoteTypeId(voteTypeId, limit, offset);

			return this.DalVoteMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e893a7c662d18f8192aedb2804a249d6</Hash>
</Codenesium>*/