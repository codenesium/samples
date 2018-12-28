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

		protected IBOLTeamMapper BolTeamMapper { get; private set; }

		protected IDALTeamMapper DalTeamMapper { get; private set; }

		protected IBOLChainMapper BolChainMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		private ILogger logger;

		public AbstractTeamService(
			ILogger logger,
			IMediator mediator,
			ITeamRepository teamRepository,
			IApiTeamServerRequestModelValidator teamModelValidator,
			IBOLTeamMapper bolTeamMapper,
			IDALTeamMapper dalTeamMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper)
			: base()
		{
			this.TeamRepository = teamRepository;
			this.TeamModelValidator = teamModelValidator;
			this.BolTeamMapper = bolTeamMapper;
			this.DalTeamMapper = dalTeamMapper;
			this.BolChainMapper = bolChainMapper;
			this.DalChainMapper = dalChainMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTeamServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeamRepository.All(limit, offset);

			return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeamServerResponseModel> Get(int id)
		{
			var record = await this.TeamRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeamServerResponseModel>> Create(
			ApiTeamServerRequestModel model)
		{
			CreateResponse<ApiTeamServerResponseModel> response = ValidationResponseFactory<ApiTeamServerResponseModel>.CreateResponse(await this.TeamModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTeamMapper.MapModelToBO(default(int), model);
				var record = await this.TeamRepository.Create(this.DalTeamMapper.MapBOToEF(bo));

				var businessObject = this.DalTeamMapper.MapEFToBO(record);
				response.SetRecord(this.BolTeamMapper.MapBOToModel(businessObject));
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
				var bo = this.BolTeamMapper.MapModelToBO(id, model);
				await this.TeamRepository.Update(this.DalTeamMapper.MapBOToEF(bo));

				var record = await this.TeamRepository.Get(id);

				var businessObject = this.DalTeamMapper.MapEFToBO(record);
				var apiModel = this.BolTeamMapper.MapBOToModel(businessObject);
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
				return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiChainServerResponseModel>> ChainsByTeamId(int teamId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.TeamRepository.ChainsByTeamId(teamId, limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>50cf565f7c9ffe857e8e9490e7b77f2b</Hash>
</Codenesium>*/