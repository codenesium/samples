using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractOrganizationService : AbstractService
	{
		private IMediator mediator;

		protected IOrganizationRepository OrganizationRepository { get; private set; }

		protected IApiOrganizationServerRequestModelValidator OrganizationModelValidator { get; private set; }

		protected IBOLOrganizationMapper BolOrganizationMapper { get; private set; }

		protected IDALOrganizationMapper DalOrganizationMapper { get; private set; }

		protected IBOLTeamMapper BolTeamMapper { get; private set; }

		protected IDALTeamMapper DalTeamMapper { get; private set; }

		private ILogger logger;

		public AbstractOrganizationService(
			ILogger logger,
			IMediator mediator,
			IOrganizationRepository organizationRepository,
			IApiOrganizationServerRequestModelValidator organizationModelValidator,
			IBOLOrganizationMapper bolOrganizationMapper,
			IDALOrganizationMapper dalOrganizationMapper,
			IBOLTeamMapper bolTeamMapper,
			IDALTeamMapper dalTeamMapper)
			: base()
		{
			this.OrganizationRepository = organizationRepository;
			this.OrganizationModelValidator = organizationModelValidator;
			this.BolOrganizationMapper = bolOrganizationMapper;
			this.DalOrganizationMapper = dalOrganizationMapper;
			this.BolTeamMapper = bolTeamMapper;
			this.DalTeamMapper = dalTeamMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOrganizationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.OrganizationRepository.All(limit, offset);

			return this.BolOrganizationMapper.MapBOToModel(this.DalOrganizationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOrganizationServerResponseModel> Get(int id)
		{
			var record = await this.OrganizationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolOrganizationMapper.MapBOToModel(this.DalOrganizationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiOrganizationServerResponseModel>> Create(
			ApiOrganizationServerRequestModel model)
		{
			CreateResponse<ApiOrganizationServerResponseModel> response = ValidationResponseFactory<ApiOrganizationServerResponseModel>.CreateResponse(await this.OrganizationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolOrganizationMapper.MapModelToBO(default(int), model);
				var record = await this.OrganizationRepository.Create(this.DalOrganizationMapper.MapBOToEF(bo));

				var businessObject = this.DalOrganizationMapper.MapEFToBO(record);
				response.SetRecord(this.BolOrganizationMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new OrganizationCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOrganizationServerResponseModel>> Update(
			int id,
			ApiOrganizationServerRequestModel model)
		{
			var validationResult = await this.OrganizationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolOrganizationMapper.MapModelToBO(id, model);
				await this.OrganizationRepository.Update(this.DalOrganizationMapper.MapBOToEF(bo));

				var record = await this.OrganizationRepository.Get(id);

				var businessObject = this.DalOrganizationMapper.MapEFToBO(record);
				var apiModel = this.BolOrganizationMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new OrganizationUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiOrganizationServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiOrganizationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OrganizationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.OrganizationRepository.Delete(id);

				await this.mediator.Publish(new OrganizationDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiOrganizationServerResponseModel> ByName(string name)
		{
			Organization record = await this.OrganizationRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolOrganizationMapper.MapBOToModel(this.DalOrganizationMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiTeamServerResponseModel>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Team> records = await this.OrganizationRepository.TeamsByOrganizationId(organizationId, limit, offset);

			return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7fa3be3fb98d964f76811925f79bd5c5</Hash>
</Codenesium>*/