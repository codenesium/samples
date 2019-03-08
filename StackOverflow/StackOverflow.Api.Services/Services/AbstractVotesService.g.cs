using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractVotesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVotesRepository VotesRepository { get; private set; }

		protected IApiVotesServerRequestModelValidator VotesModelValidator { get; private set; }

		protected IDALVotesMapper DalVotesMapper { get; private set; }

		private ILogger logger;

		public AbstractVotesService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVotesRepository votesRepository,
			IApiVotesServerRequestModelValidator votesModelValidator,
			IDALVotesMapper dalVotesMapper)
			: base()
		{
			this.VotesRepository = votesRepository;
			this.VotesModelValidator = votesModelValidator;
			this.DalVotesMapper = dalVotesMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVotesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Votes> records = await this.VotesRepository.All(limit, offset, query);

			return this.DalVotesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVotesServerResponseModel> Get(int id)
		{
			Votes record = await this.VotesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVotesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVotesServerResponseModel>> Create(
			ApiVotesServerRequestModel model)
		{
			CreateResponse<ApiVotesServerResponseModel> response = ValidationResponseFactory<ApiVotesServerResponseModel>.CreateResponse(await this.VotesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Votes record = this.DalVotesMapper.MapModelToEntity(default(int), model);
				record = await this.VotesRepository.Create(record);

				response.SetRecord(this.DalVotesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VotesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVotesServerResponseModel>> Update(
			int id,
			ApiVotesServerRequestModel model)
		{
			var validationResult = await this.VotesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Votes record = this.DalVotesMapper.MapModelToEntity(id, model);
				await this.VotesRepository.Update(record);

				record = await this.VotesRepository.Get(id);

				ApiVotesServerResponseModel apiModel = this.DalVotesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VotesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVotesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVotesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VotesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VotesRepository.Delete(id);

				await this.mediator.Publish(new VotesDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVotesServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Votes> records = await this.VotesRepository.ByUserId(userId, limit, offset);

			return this.DalVotesMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVotesServerResponseModel>> ByPostId(int postId, int limit = 0, int offset = int.MaxValue)
		{
			List<Votes> records = await this.VotesRepository.ByPostId(postId, limit, offset);

			return this.DalVotesMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVotesServerResponseModel>> ByVoteTypeId(int voteTypeId, int limit = 0, int offset = int.MaxValue)
		{
			List<Votes> records = await this.VotesRepository.ByVoteTypeId(voteTypeId, limit, offset);

			return this.DalVotesMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>bd44bfc816e73675c83ead9825119747</Hash>
</Codenesium>*/