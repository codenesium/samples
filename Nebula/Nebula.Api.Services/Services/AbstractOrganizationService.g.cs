using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractOrganizationService : AbstractService
	{
		protected IOrganizationRepository OrganizationRepository { get; private set; }

		protected IApiOrganizationRequestModelValidator OrganizationModelValidator { get; private set; }

		protected IBOLOrganizationMapper BolOrganizationMapper { get; private set; }

		protected IDALOrganizationMapper DalOrganizationMapper { get; private set; }

		protected IBOLTeamMapper BolTeamMapper { get; private set; }

		protected IDALTeamMapper DalTeamMapper { get; private set; }

		private ILogger logger;

		public AbstractOrganizationService(
			ILogger logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationRequestModelValidator organizationModelValidator,
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
		}

		public virtual async Task<List<ApiOrganizationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.OrganizationRepository.All(limit, offset);

			return this.BolOrganizationMapper.MapBOToModel(this.DalOrganizationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOrganizationResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiOrganizationResponseModel>> Create(
			ApiOrganizationRequestModel model)
		{
			CreateResponse<ApiOrganizationResponseModel> response = new CreateResponse<ApiOrganizationResponseModel>(await this.OrganizationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolOrganizationMapper.MapModelToBO(default(int), model);
				var record = await this.OrganizationRepository.Create(this.DalOrganizationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolOrganizationMapper.MapBOToModel(this.DalOrganizationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOrganizationResponseModel>> Update(
			int id,
			ApiOrganizationRequestModel model)
		{
			var validationResult = await this.OrganizationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolOrganizationMapper.MapModelToBO(id, model);
				await this.OrganizationRepository.Update(this.DalOrganizationMapper.MapBOToEF(bo));

				var record = await this.OrganizationRepository.Get(id);

				return new UpdateResponse<ApiOrganizationResponseModel>(this.BolOrganizationMapper.MapBOToModel(this.DalOrganizationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiOrganizationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.OrganizationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.OrganizationRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTeamResponseModel>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Team> records = await this.OrganizationRepository.Teams(organizationId, limit, offset);

			return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>39f9a304b149c612052fcb56535dfa36</Hash>
</Codenesium>*/