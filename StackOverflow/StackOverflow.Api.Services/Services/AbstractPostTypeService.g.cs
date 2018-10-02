using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostTypeService : AbstractService
	{
		protected IPostTypeRepository PostTypeRepository { get; private set; }

		protected IApiPostTypeRequestModelValidator PostTypeModelValidator { get; private set; }

		protected IBOLPostTypeMapper BolPostTypeMapper { get; private set; }

		protected IDALPostTypeMapper DalPostTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPostTypeService(
			ILogger logger,
			IPostTypeRepository postTypeRepository,
			IApiPostTypeRequestModelValidator postTypeModelValidator,
			IBOLPostTypeMapper bolPostTypeMapper,
			IDALPostTypeMapper dalPostTypeMapper)
			: base()
		{
			this.PostTypeRepository = postTypeRepository;
			this.PostTypeModelValidator = postTypeModelValidator;
			this.BolPostTypeMapper = bolPostTypeMapper;
			this.DalPostTypeMapper = dalPostTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostTypeRepository.All(limit, offset);

			return this.BolPostTypeMapper.MapBOToModel(this.DalPostTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostTypeResponseModel> Get(int id)
		{
			var record = await this.PostTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostTypeMapper.MapBOToModel(this.DalPostTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostTypeResponseModel>> Create(
			ApiPostTypeRequestModel model)
		{
			CreateResponse<ApiPostTypeResponseModel> response = new CreateResponse<ApiPostTypeResponseModel>(await this.PostTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PostTypeRepository.Create(this.DalPostTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostTypeMapper.MapBOToModel(this.DalPostTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostTypeResponseModel>> Update(
			int id,
			ApiPostTypeRequestModel model)
		{
			var validationResult = await this.PostTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostTypeMapper.MapModelToBO(id, model);
				await this.PostTypeRepository.Update(this.DalPostTypeMapper.MapBOToEF(bo));

				var record = await this.PostTypeRepository.Get(id);

				return new UpdateResponse<ApiPostTypeResponseModel>(this.BolPostTypeMapper.MapBOToModel(this.DalPostTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostTypeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostTypeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6457dbf4b6dde188ef201a062223bc64</Hash>
</Codenesium>*/