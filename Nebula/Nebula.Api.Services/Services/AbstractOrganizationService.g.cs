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
		private MediatR.IMediator mediator;

		protected IOrganizationRepository OrganizationRepository { get; private set; }

		protected IApiOrganizationServerRequestModelValidator OrganizationModelValidator { get; private set; }

		protected IDALOrganizationMapper DalOrganizationMapper { get; private set; }

		protected IDALTeamMapper DalTeamMapper { get; private set; }

		private ILogger logger;

		public AbstractOrganizationService(
			ILogger logger,
			MediatR.IMediator mediator,
			IOrganizationRepository organizationRepository,
			IApiOrganizationServerRequestModelValidator organizationModelValidator,
			IDALOrganizationMapper dalOrganizationMapper,
			IDALTeamMapper dalTeamMapper)
			: base()
		{
			this.OrganizationRepository = organizationRepository;
			this.OrganizationModelValidator = organizationModelValidator;
			this.DalOrganizationMapper = dalOrganizationMapper;
			this.DalTeamMapper = dalTeamMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOrganizationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Organization> records = await this.OrganizationRepository.All(limit, offset, query);

			return this.DalOrganizationMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOrganizationServerResponseModel> Get(int id)
		{
			Organization record = await this.OrganizationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalOrganizationMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiOrganizationServerResponseModel>> Create(
			ApiOrganizationServerRequestModel model)
		{
			CreateResponse<ApiOrganizationServerResponseModel> response = ValidationResponseFactory<ApiOrganizationServerResponseModel>.CreateResponse(await this.OrganizationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Organization record = this.DalOrganizationMapper.MapModelToEntity(default(int), model);
				record = await this.OrganizationRepository.Create(record);

				response.SetRecord(this.DalOrganizationMapper.MapEntityToModel(record));
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
				Organization record = this.DalOrganizationMapper.MapModelToEntity(id, model);
				await this.OrganizationRepository.Update(record);

				record = await this.OrganizationRepository.Get(id);

				ApiOrganizationServerResponseModel apiModel = this.DalOrganizationMapper.MapEntityToModel(record);
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
				return this.DalOrganizationMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiTeamServerResponseModel>> TeamsByOrganizationId(int organizationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Team> records = await this.OrganizationRepository.TeamsByOrganizationId(organizationId, limit, offset);

			return this.DalTeamMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7af65513b543807760c824fc6412a1d7</Hash>
</Codenesium>*/