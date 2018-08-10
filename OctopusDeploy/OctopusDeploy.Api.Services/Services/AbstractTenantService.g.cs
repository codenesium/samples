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
	public abstract class AbstractTenantService : AbstractService
	{
		protected ITenantRepository TenantRepository { get; private set; }

		protected IApiTenantRequestModelValidator TenantModelValidator { get; private set; }

		protected IBOLTenantMapper BolTenantMapper { get; private set; }

		protected IDALTenantMapper DalTenantMapper { get; private set; }

		private ILogger logger;

		public AbstractTenantService(
			ILogger logger,
			ITenantRepository tenantRepository,
			IApiTenantRequestModelValidator tenantModelValidator,
			IBOLTenantMapper bolTenantMapper,
			IDALTenantMapper dalTenantMapper)
			: base()
		{
			this.TenantRepository = tenantRepository;
			this.TenantModelValidator = tenantModelValidator;
			this.BolTenantMapper = bolTenantMapper;
			this.DalTenantMapper = dalTenantMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTenantResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TenantRepository.All(limit, offset);

			return this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTenantResponseModel> Get(string id)
		{
			var record = await this.TenantRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTenantResponseModel>> Create(
			ApiTenantRequestModel model)
		{
			CreateResponse<ApiTenantResponseModel> response = new CreateResponse<ApiTenantResponseModel>(await this.TenantModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTenantMapper.MapModelToBO(default(string), model);
				var record = await this.TenantRepository.Create(this.DalTenantMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTenantResponseModel>> Update(
			string id,
			ApiTenantRequestModel model)
		{
			var validationResult = await this.TenantModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTenantMapper.MapModelToBO(id, model);
				await this.TenantRepository.Update(this.DalTenantMapper.MapBOToEF(bo));

				var record = await this.TenantRepository.Get(id);

				return new UpdateResponse<ApiTenantResponseModel>(this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTenantResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.TenantModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TenantRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiTenantResponseModel> ByName(string name)
		{
			Tenant record = await this.TenantRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiTenantResponseModel>> ByDataVersion(byte[] dataVersion)
		{
			List<Tenant> records = await this.TenantRepository.ByDataVersion(dataVersion);

			return this.BolTenantMapper.MapBOToModel(this.DalTenantMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b8f5d6aba991babf492f4d8d07c6cfe7</Hash>
</Codenesium>*/