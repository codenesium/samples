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
	public abstract class AbstractCommunityActionTemplateService : AbstractService
	{
		protected ICommunityActionTemplateRepository CommunityActionTemplateRepository { get; private set; }

		protected IApiCommunityActionTemplateRequestModelValidator CommunityActionTemplateModelValidator { get; private set; }

		protected IBOLCommunityActionTemplateMapper BolCommunityActionTemplateMapper { get; private set; }

		protected IDALCommunityActionTemplateMapper DalCommunityActionTemplateMapper { get; private set; }

		private ILogger logger;

		public AbstractCommunityActionTemplateService(
			ILogger logger,
			ICommunityActionTemplateRepository communityActionTemplateRepository,
			IApiCommunityActionTemplateRequestModelValidator communityActionTemplateModelValidator,
			IBOLCommunityActionTemplateMapper bolCommunityActionTemplateMapper,
			IDALCommunityActionTemplateMapper dalCommunityActionTemplateMapper)
			: base()
		{
			this.CommunityActionTemplateRepository = communityActionTemplateRepository;
			this.CommunityActionTemplateModelValidator = communityActionTemplateModelValidator;
			this.BolCommunityActionTemplateMapper = bolCommunityActionTemplateMapper;
			this.DalCommunityActionTemplateMapper = dalCommunityActionTemplateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCommunityActionTemplateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CommunityActionTemplateRepository.All(limit, offset);

			return this.BolCommunityActionTemplateMapper.MapBOToModel(this.DalCommunityActionTemplateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCommunityActionTemplateResponseModel> Get(string id)
		{
			var record = await this.CommunityActionTemplateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCommunityActionTemplateMapper.MapBOToModel(this.DalCommunityActionTemplateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCommunityActionTemplateResponseModel>> Create(
			ApiCommunityActionTemplateRequestModel model)
		{
			CreateResponse<ApiCommunityActionTemplateResponseModel> response = new CreateResponse<ApiCommunityActionTemplateResponseModel>(await this.CommunityActionTemplateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCommunityActionTemplateMapper.MapModelToBO(default(string), model);
				var record = await this.CommunityActionTemplateRepository.Create(this.DalCommunityActionTemplateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCommunityActionTemplateMapper.MapBOToModel(this.DalCommunityActionTemplateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCommunityActionTemplateResponseModel>> Update(
			string id,
			ApiCommunityActionTemplateRequestModel model)
		{
			var validationResult = await this.CommunityActionTemplateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCommunityActionTemplateMapper.MapModelToBO(id, model);
				await this.CommunityActionTemplateRepository.Update(this.DalCommunityActionTemplateMapper.MapBOToEF(bo));

				var record = await this.CommunityActionTemplateRepository.Get(id);

				return new UpdateResponse<ApiCommunityActionTemplateResponseModel>(this.BolCommunityActionTemplateMapper.MapBOToModel(this.DalCommunityActionTemplateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCommunityActionTemplateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.CommunityActionTemplateModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CommunityActionTemplateRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiCommunityActionTemplateResponseModel> ByExternalId(Guid externalId)
		{
			CommunityActionTemplate record = await this.CommunityActionTemplateRepository.ByExternalId(externalId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCommunityActionTemplateMapper.MapBOToModel(this.DalCommunityActionTemplateMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiCommunityActionTemplateResponseModel> ByName(string name)
		{
			CommunityActionTemplate record = await this.CommunityActionTemplateRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCommunityActionTemplateMapper.MapBOToModel(this.DalCommunityActionTemplateMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>929f9182757ae5c9f81c359423d95717</Hash>
</Codenesium>*/