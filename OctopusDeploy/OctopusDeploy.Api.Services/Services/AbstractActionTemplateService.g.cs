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
	public abstract class AbstractActionTemplateService : AbstractService
	{
		protected IActionTemplateRepository ActionTemplateRepository { get; private set; }

		protected IApiActionTemplateRequestModelValidator ActionTemplateModelValidator { get; private set; }

		protected IBOLActionTemplateMapper BolActionTemplateMapper { get; private set; }

		protected IDALActionTemplateMapper DalActionTemplateMapper { get; private set; }

		private ILogger logger;

		public AbstractActionTemplateService(
			ILogger logger,
			IActionTemplateRepository actionTemplateRepository,
			IApiActionTemplateRequestModelValidator actionTemplateModelValidator,
			IBOLActionTemplateMapper bolActionTemplateMapper,
			IDALActionTemplateMapper dalActionTemplateMapper)
			: base()
		{
			this.ActionTemplateRepository = actionTemplateRepository;
			this.ActionTemplateModelValidator = actionTemplateModelValidator;
			this.BolActionTemplateMapper = bolActionTemplateMapper;
			this.DalActionTemplateMapper = dalActionTemplateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiActionTemplateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ActionTemplateRepository.All(limit, offset);

			return this.BolActionTemplateMapper.MapBOToModel(this.DalActionTemplateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiActionTemplateResponseModel> Get(string id)
		{
			var record = await this.ActionTemplateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolActionTemplateMapper.MapBOToModel(this.DalActionTemplateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiActionTemplateResponseModel>> Create(
			ApiActionTemplateRequestModel model)
		{
			CreateResponse<ApiActionTemplateResponseModel> response = new CreateResponse<ApiActionTemplateResponseModel>(await this.ActionTemplateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolActionTemplateMapper.MapModelToBO(default(string), model);
				var record = await this.ActionTemplateRepository.Create(this.DalActionTemplateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolActionTemplateMapper.MapBOToModel(this.DalActionTemplateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiActionTemplateResponseModel>> Update(
			string id,
			ApiActionTemplateRequestModel model)
		{
			var validationResult = await this.ActionTemplateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolActionTemplateMapper.MapModelToBO(id, model);
				await this.ActionTemplateRepository.Update(this.DalActionTemplateMapper.MapBOToEF(bo));

				var record = await this.ActionTemplateRepository.Get(id);

				return new UpdateResponse<ApiActionTemplateResponseModel>(this.BolActionTemplateMapper.MapBOToModel(this.DalActionTemplateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiActionTemplateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ActionTemplateModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ActionTemplateRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiActionTemplateResponseModel> ByName(string name)
		{
			ActionTemplate record = await this.ActionTemplateRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolActionTemplateMapper.MapBOToModel(this.DalActionTemplateMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>3a3510919be7f1fec6f69e34258db337</Hash>
</Codenesium>*/