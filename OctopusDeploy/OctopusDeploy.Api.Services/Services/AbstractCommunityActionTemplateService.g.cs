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
		private ICommunityActionTemplateRepository communityActionTemplateRepository;

		private IApiCommunityActionTemplateRequestModelValidator communityActionTemplateModelValidator;

		private IBOLCommunityActionTemplateMapper bolCommunityActionTemplateMapper;

		private IDALCommunityActionTemplateMapper dalCommunityActionTemplateMapper;

		private ILogger logger;

		public AbstractCommunityActionTemplateService(
			ILogger logger,
			ICommunityActionTemplateRepository communityActionTemplateRepository,
			IApiCommunityActionTemplateRequestModelValidator communityActionTemplateModelValidator,
			IBOLCommunityActionTemplateMapper bolCommunityActionTemplateMapper,
			IDALCommunityActionTemplateMapper dalCommunityActionTemplateMapper)
			: base()
		{
			this.communityActionTemplateRepository = communityActionTemplateRepository;
			this.communityActionTemplateModelValidator = communityActionTemplateModelValidator;
			this.bolCommunityActionTemplateMapper = bolCommunityActionTemplateMapper;
			this.dalCommunityActionTemplateMapper = dalCommunityActionTemplateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCommunityActionTemplateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.communityActionTemplateRepository.All(limit, offset);

			return this.bolCommunityActionTemplateMapper.MapBOToModel(this.dalCommunityActionTemplateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCommunityActionTemplateResponseModel> Get(string id)
		{
			var record = await this.communityActionTemplateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCommunityActionTemplateMapper.MapBOToModel(this.dalCommunityActionTemplateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCommunityActionTemplateResponseModel>> Create(
			ApiCommunityActionTemplateRequestModel model)
		{
			CreateResponse<ApiCommunityActionTemplateResponseModel> response = new CreateResponse<ApiCommunityActionTemplateResponseModel>(await this.communityActionTemplateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCommunityActionTemplateMapper.MapModelToBO(default(string), model);
				var record = await this.communityActionTemplateRepository.Create(this.dalCommunityActionTemplateMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCommunityActionTemplateMapper.MapBOToModel(this.dalCommunityActionTemplateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCommunityActionTemplateResponseModel>> Update(
			string id,
			ApiCommunityActionTemplateRequestModel model)
		{
			var validationResult = await this.communityActionTemplateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolCommunityActionTemplateMapper.MapModelToBO(id, model);
				await this.communityActionTemplateRepository.Update(this.dalCommunityActionTemplateMapper.MapBOToEF(bo));

				var record = await this.communityActionTemplateRepository.Get(id);

				return new UpdateResponse<ApiCommunityActionTemplateResponseModel>(this.bolCommunityActionTemplateMapper.MapBOToModel(this.dalCommunityActionTemplateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCommunityActionTemplateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.communityActionTemplateModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.communityActionTemplateRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiCommunityActionTemplateResponseModel> ByExternalId(Guid externalId)
		{
			CommunityActionTemplate record = await this.communityActionTemplateRepository.ByExternalId(externalId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCommunityActionTemplateMapper.MapBOToModel(this.dalCommunityActionTemplateMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiCommunityActionTemplateResponseModel> ByName(string name)
		{
			CommunityActionTemplate record = await this.communityActionTemplateRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolCommunityActionTemplateMapper.MapBOToModel(this.dalCommunityActionTemplateMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>631abb7c268799318719cad91592bfd1</Hash>
</Codenesium>*/