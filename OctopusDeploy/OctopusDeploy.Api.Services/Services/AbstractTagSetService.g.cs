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
	public abstract class AbstractTagSetService : AbstractService
	{
		protected ITagSetRepository TagSetRepository { get; private set; }

		protected IApiTagSetRequestModelValidator TagSetModelValidator { get; private set; }

		protected IBOLTagSetMapper BolTagSetMapper { get; private set; }

		protected IDALTagSetMapper DalTagSetMapper { get; private set; }

		private ILogger logger;

		public AbstractTagSetService(
			ILogger logger,
			ITagSetRepository tagSetRepository,
			IApiTagSetRequestModelValidator tagSetModelValidator,
			IBOLTagSetMapper bolTagSetMapper,
			IDALTagSetMapper dalTagSetMapper)
			: base()
		{
			this.TagSetRepository = tagSetRepository;
			this.TagSetModelValidator = tagSetModelValidator;
			this.BolTagSetMapper = bolTagSetMapper;
			this.DalTagSetMapper = dalTagSetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTagSetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TagSetRepository.All(limit, offset);

			return this.BolTagSetMapper.MapBOToModel(this.DalTagSetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTagSetResponseModel> Get(string id)
		{
			var record = await this.TagSetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTagSetMapper.MapBOToModel(this.DalTagSetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTagSetResponseModel>> Create(
			ApiTagSetRequestModel model)
		{
			CreateResponse<ApiTagSetResponseModel> response = new CreateResponse<ApiTagSetResponseModel>(await this.TagSetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTagSetMapper.MapModelToBO(default(string), model);
				var record = await this.TagSetRepository.Create(this.DalTagSetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTagSetMapper.MapBOToModel(this.DalTagSetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTagSetResponseModel>> Update(
			string id,
			ApiTagSetRequestModel model)
		{
			var validationResult = await this.TagSetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTagSetMapper.MapModelToBO(id, model);
				await this.TagSetRepository.Update(this.DalTagSetMapper.MapBOToEF(bo));

				var record = await this.TagSetRepository.Get(id);

				return new UpdateResponse<ApiTagSetResponseModel>(this.BolTagSetMapper.MapBOToModel(this.DalTagSetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTagSetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.TagSetModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TagSetRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiTagSetResponseModel> ByName(string name)
		{
			TagSet record = await this.TagSetRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTagSetMapper.MapBOToModel(this.DalTagSetMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiTagSetResponseModel>> ByDataVersion(byte[] dataVersion)
		{
			List<TagSet> records = await this.TagSetRepository.ByDataVersion(dataVersion);

			return this.BolTagSetMapper.MapBOToModel(this.DalTagSetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6623577867c33e9b5e239210ba460f0c</Hash>
</Codenesium>*/