using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractTenantVariableService : AbstractService
	{
		protected ITenantVariableRepository TenantVariableRepository { get; private set; }

		protected IApiTenantVariableRequestModelValidator TenantVariableModelValidator { get; private set; }

		protected IBOLTenantVariableMapper BolTenantVariableMapper { get; private set; }

		protected IDALTenantVariableMapper DalTenantVariableMapper { get; private set; }

		private ILogger logger;

		public AbstractTenantVariableService(
			ILogger logger,
			ITenantVariableRepository tenantVariableRepository,
			IApiTenantVariableRequestModelValidator tenantVariableModelValidator,
			IBOLTenantVariableMapper bolTenantVariableMapper,
			IDALTenantVariableMapper dalTenantVariableMapper)
			: base()
		{
			this.TenantVariableRepository = tenantVariableRepository;
			this.TenantVariableModelValidator = tenantVariableModelValidator;
			this.BolTenantVariableMapper = bolTenantVariableMapper;
			this.DalTenantVariableMapper = dalTenantVariableMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTenantVariableResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TenantVariableRepository.All(limit, offset);

			return this.BolTenantVariableMapper.MapBOToModel(this.DalTenantVariableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTenantVariableResponseModel> Get(string id)
		{
			var record = await this.TenantVariableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTenantVariableMapper.MapBOToModel(this.DalTenantVariableMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTenantVariableResponseModel>> Create(
			ApiTenantVariableRequestModel model)
		{
			CreateResponse<ApiTenantVariableResponseModel> response = new CreateResponse<ApiTenantVariableResponseModel>(await this.TenantVariableModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTenantVariableMapper.MapModelToBO(default(string), model);
				var record = await this.TenantVariableRepository.Create(this.DalTenantVariableMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTenantVariableMapper.MapBOToModel(this.DalTenantVariableMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTenantVariableResponseModel>> Update(
			string id,
			ApiTenantVariableRequestModel model)
		{
			var validationResult = await this.TenantVariableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTenantVariableMapper.MapModelToBO(id, model);
				await this.TenantVariableRepository.Update(this.DalTenantVariableMapper.MapBOToEF(bo));

				var record = await this.TenantVariableRepository.Get(id);

				return new UpdateResponse<ApiTenantVariableResponseModel>(this.BolTenantVariableMapper.MapBOToModel(this.DalTenantVariableMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTenantVariableResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.TenantVariableModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TenantVariableRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiTenantVariableResponseModel> ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId)
		{
			TenantVariable record = await this.TenantVariableRepository.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(tenantId, ownerId, environmentId, variableTemplateId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTenantVariableMapper.MapBOToModel(this.DalTenantVariableMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiTenantVariableResponseModel>> ByTenantId(string tenantId)
		{
			List<TenantVariable> records = await this.TenantVariableRepository.ByTenantId(tenantId);

			return this.BolTenantVariableMapper.MapBOToModel(this.DalTenantVariableMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>af002a78e0a8bd0a2ee02d2ed8173429</Hash>
</Codenesium>*/