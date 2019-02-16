using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractTeamService : AbstractService
	{
		private IMediator mediator;

		protected ITeamRepository TeamRepository { get; private set; }

		protected IApiTeamServerRequestModelValidator TeamModelValidator { get; private set; }

		protected IDALTeamMapper DalTeamMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		private ILogger logger;

		public AbstractTeamService(
			ILogger logger,
			IMediator mediator,
			ITeamRepository teamRepository,
			IApiTeamServerRequestModelValidator teamModelValidator,
			IDALTeamMapper dalTeamMapper,
			IDALChainMapper dalChainMapper)
			: base()
		{
			this.TeamRepository = teamRepository;
			this.TeamModelValidator = teamModelValidator;
			this.DalTeamMapper = dalTeamMapper;
			this.DalChainMapper = dalChainMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTeamServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Team> records = await this.TeamRepository.All(limit, offset, query);

			return this.DalTeamMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTeamServerResponseModel> Get(int id)
		{
			Team record = await this.TeamRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTeamMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTeamServerResponseModel>> Create(
			ApiTeamServerRequestModel model)
		{
			CreateResponse<ApiTeamServerResponseModel> response = ValidationResponseFactory<ApiTeamServerResponseModel>.CreateResponse(await this.TeamModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Team record = this.DalTeamMapper.MapModelToEntity(default(int), model);
				record = await this.TeamRepository.Create(record);

				response.SetRecord(this.DalTeamMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TeamCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeamServerResponseModel>> Update(
			int id,
			ApiTeamServerRequestModel model)
		{
			var validationResult = await this.TeamModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Team record = this.DalTeamMapper.MapModelToEntity(id, model);
				await this.TeamRepository.Update(record);

				record = await this.TeamRepository.Get(id);

				ApiTeamServerResponseModel apiModel = this.DalTeamMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TeamUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTeamServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTeamServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TeamModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TeamRepository.Delete(id);

				await this.mediator.Publish(new TeamDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiTeamServerResponseModel> ByName(string name)
		{
			Team record = await this.TeamRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTeamMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiChainServerResponseModel>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.TeamRepository.ChainsByTeamId(teamId, limit, offset);

			return this.DalChainMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>3d2166e0326ce13e9164146c7c4f13f4</Hash>
</Codenesium>*/