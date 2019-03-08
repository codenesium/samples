using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractVoteTypesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVoteTypesRepository VoteTypesRepository { get; private set; }

		protected IApiVoteTypesServerRequestModelValidator VoteTypesModelValidator { get; private set; }

		protected IDALVoteTypesMapper DalVoteTypesMapper { get; private set; }

		protected IDALVotesMapper DalVotesMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteTypesService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVoteTypesRepository voteTypesRepository,
			IApiVoteTypesServerRequestModelValidator voteTypesModelValidator,
			IDALVoteTypesMapper dalVoteTypesMapper,
			IDALVotesMapper dalVotesMapper)
			: base()
		{
			this.VoteTypesRepository = voteTypesRepository;
			this.VoteTypesModelValidator = voteTypesModelValidator;
			this.DalVoteTypesMapper = dalVoteTypesMapper;
			this.DalVotesMapper = dalVotesMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVoteTypesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VoteTypes> records = await this.VoteTypesRepository.All(limit, offset, query);

			return this.DalVoteTypesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVoteTypesServerResponseModel> Get(int id)
		{
			VoteTypes record = await this.VoteTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVoteTypesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVoteTypesServerResponseModel>> Create(
			ApiVoteTypesServerRequestModel model)
		{
			CreateResponse<ApiVoteTypesServerResponseModel> response = ValidationResponseFactory<ApiVoteTypesServerResponseModel>.CreateResponse(await this.VoteTypesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VoteTypes record = this.DalVoteTypesMapper.MapModelToEntity(default(int), model);
				record = await this.VoteTypesRepository.Create(record);

				response.SetRecord(this.DalVoteTypesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VoteTypesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteTypesServerResponseModel>> Update(
			int id,
			ApiVoteTypesServerRequestModel model)
		{
			var validationResult = await this.VoteTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				VoteTypes record = this.DalVoteTypesMapper.MapModelToEntity(id, model);
				await this.VoteTypesRepository.Update(record);

				record = await this.VoteTypesRepository.Get(id);

				ApiVoteTypesServerResponseModel apiModel = this.DalVoteTypesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VoteTypesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVoteTypesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVoteTypesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VoteTypesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VoteTypesRepository.Delete(id);

				await this.mediator.Publish(new VoteTypesDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVotesServerResponseModel>> VotesByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<Votes> records = await this.VoteTypesRepository.VotesByVoteTypeId(voteTypeId, limit, offset);

			return this.DalVotesMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>ef772c8cf19fbc4570e5a31da865d6e6</Hash>
</Codenesium>*/