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
	public abstract class AbstractSysdiagramService : AbstractService
	{
		protected ISysdiagramRepository SysdiagramRepository { get; private set; }

		protected IApiSysdiagramRequestModelValidator SysdiagramModelValidator { get; private set; }

		protected IBOLSysdiagramMapper BolSysdiagramMapper { get; private set; }

		protected IDALSysdiagramMapper DalSysdiagramMapper { get; private set; }

		private ILogger logger;

		public AbstractSysdiagramService(
			ILogger logger,
			ISysdiagramRepository sysdiagramRepository,
			IApiSysdiagramRequestModelValidator sysdiagramModelValidator,
			IBOLSysdiagramMapper bolSysdiagramMapper,
			IDALSysdiagramMapper dalSysdiagramMapper)
			: base()
		{
			this.SysdiagramRepository = sysdiagramRepository;
			this.SysdiagramModelValidator = sysdiagramModelValidator;
			this.BolSysdiagramMapper = bolSysdiagramMapper;
			this.DalSysdiagramMapper = dalSysdiagramMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSysdiagramResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SysdiagramRepository.All(limit, offset);

			return this.BolSysdiagramMapper.MapBOToModel(this.DalSysdiagramMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSysdiagramResponseModel> Get(int diagramId)
		{
			var record = await this.SysdiagramRepository.Get(diagramId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSysdiagramMapper.MapBOToModel(this.DalSysdiagramMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSysdiagramResponseModel>> Create(
			ApiSysdiagramRequestModel model)
		{
			CreateResponse<ApiSysdiagramResponseModel> response = new CreateResponse<ApiSysdiagramResponseModel>(await this.SysdiagramModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSysdiagramMapper.MapModelToBO(default(int), model);
				var record = await this.SysdiagramRepository.Create(this.DalSysdiagramMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSysdiagramMapper.MapBOToModel(this.DalSysdiagramMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSysdiagramResponseModel>> Update(
			int diagramId,
			ApiSysdiagramRequestModel model)
		{
			var validationResult = await this.SysdiagramModelValidator.ValidateUpdateAsync(diagramId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSysdiagramMapper.MapModelToBO(diagramId, model);
				await this.SysdiagramRepository.Update(this.DalSysdiagramMapper.MapBOToEF(bo));

				var record = await this.SysdiagramRepository.Get(diagramId);

				return new UpdateResponse<ApiSysdiagramResponseModel>(this.BolSysdiagramMapper.MapBOToModel(this.DalSysdiagramMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSysdiagramResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int diagramId)
		{
			ActionResponse response = new ActionResponse(await this.SysdiagramModelValidator.ValidateDeleteAsync(diagramId));
			if (response.Success)
			{
				await this.SysdiagramRepository.Delete(diagramId);
			}

			return response;
		}

		public async Task<ApiSysdiagramResponseModel> ByPrincipalIdName(int principalId, string name)
		{
			Sysdiagram record = await this.SysdiagramRepository.ByPrincipalIdName(principalId, name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSysdiagramMapper.MapBOToModel(this.DalSysdiagramMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>8de7d3515c452430b4a6383424a092ab</Hash>
</Codenesium>*/