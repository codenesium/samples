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
	public abstract class AbstractLinkTypeService : AbstractService
	{
		protected ILinkTypeRepository LinkTypeRepository { get; private set; }

		protected IApiLinkTypeRequestModelValidator LinkTypeModelValidator { get; private set; }

		protected IBOLLinkTypeMapper BolLinkTypeMapper { get; private set; }

		protected IDALLinkTypeMapper DalLinkTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkTypeService(
			ILogger logger,
			ILinkTypeRepository linkTypeRepository,
			IApiLinkTypeRequestModelValidator linkTypeModelValidator,
			IBOLLinkTypeMapper bolLinkTypeMapper,
			IDALLinkTypeMapper dalLinkTypeMapper)
			: base()
		{
			this.LinkTypeRepository = linkTypeRepository;
			this.LinkTypeModelValidator = linkTypeModelValidator;
			this.BolLinkTypeMapper = bolLinkTypeMapper;
			this.DalLinkTypeMapper = dalLinkTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkTypeRepository.All(limit, offset);

			return this.BolLinkTypeMapper.MapBOToModel(this.DalLinkTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkTypeResponseModel> Get(int id)
		{
			var record = await this.LinkTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkTypeMapper.MapBOToModel(this.DalLinkTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkTypeResponseModel>> Create(
			ApiLinkTypeRequestModel model)
		{
			CreateResponse<ApiLinkTypeResponseModel> response = new CreateResponse<ApiLinkTypeResponseModel>(await this.LinkTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLinkTypeMapper.MapModelToBO(default(int), model);
				var record = await this.LinkTypeRepository.Create(this.DalLinkTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLinkTypeMapper.MapBOToModel(this.DalLinkTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkTypeResponseModel>> Update(
			int id,
			ApiLinkTypeRequestModel model)
		{
			var validationResult = await this.LinkTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLinkTypeMapper.MapModelToBO(id, model);
				await this.LinkTypeRepository.Update(this.DalLinkTypeMapper.MapBOToEF(bo));

				var record = await this.LinkTypeRepository.Get(id);

				return new UpdateResponse<ApiLinkTypeResponseModel>(this.BolLinkTypeMapper.MapBOToModel(this.DalLinkTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLinkTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LinkTypeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LinkTypeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ebf89e7b9219e6c566aa416b5986230c</Hash>
</Codenesium>*/