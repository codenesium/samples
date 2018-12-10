using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractClaspService : AbstractService
	{
		protected IClaspRepository ClaspRepository { get; private set; }

		protected IApiClaspServerRequestModelValidator ClaspModelValidator { get; private set; }

		protected IBOLClaspMapper BolClaspMapper { get; private set; }

		protected IDALClaspMapper DalClaspMapper { get; private set; }

		private ILogger logger;

		public AbstractClaspService(
			ILogger logger,
			IClaspRepository claspRepository,
			IApiClaspServerRequestModelValidator claspModelValidator,
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper)
			: base()
		{
			this.ClaspRepository = claspRepository;
			this.ClaspModelValidator = claspModelValidator;
			this.BolClaspMapper = bolClaspMapper;
			this.DalClaspMapper = dalClaspMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClaspServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ClaspRepository.All(limit, offset);

			return this.BolClaspMapper.MapBOToModel(this.DalClaspMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClaspServerResponseModel> Get(int id)
		{
			var record = await this.ClaspRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolClaspMapper.MapBOToModel(this.DalClaspMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiClaspServerResponseModel>> Create(
			ApiClaspServerRequestModel model)
		{
			CreateResponse<ApiClaspServerResponseModel> response = ValidationResponseFactory<ApiClaspServerResponseModel>.CreateResponse(await this.ClaspModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolClaspMapper.MapModelToBO(default(int), model);
				var record = await this.ClaspRepository.Create(this.DalClaspMapper.MapBOToEF(bo));

				response.SetRecord(this.BolClaspMapper.MapBOToModel(this.DalClaspMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiClaspServerResponseModel>> Update(
			int id,
			ApiClaspServerRequestModel model)
		{
			var validationResult = await this.ClaspModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolClaspMapper.MapModelToBO(id, model);
				await this.ClaspRepository.Update(this.DalClaspMapper.MapBOToEF(bo));

				var record = await this.ClaspRepository.Get(id);

				return ValidationResponseFactory<ApiClaspServerResponseModel>.UpdateResponse(this.BolClaspMapper.MapBOToModel(this.DalClaspMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiClaspServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ClaspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ClaspRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>11cdffc1c4892b8b907b7327cabe01be</Hash>
</Codenesium>*/