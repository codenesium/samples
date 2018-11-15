using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractVPersonService : AbstractService
	{
		protected IVPersonRepository VPersonRepository { get; private set; }

		protected IApiVPersonServerRequestModelValidator VPersonModelValidator { get; private set; }

		protected IBOLVPersonMapper BolVPersonMapper { get; private set; }

		protected IDALVPersonMapper DalVPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractVPersonService(
			ILogger logger,
			IVPersonRepository vPersonRepository,
			IApiVPersonServerRequestModelValidator vPersonModelValidator,
			IBOLVPersonMapper bolVPersonMapper,
			IDALVPersonMapper dalVPersonMapper)
			: base()
		{
			this.VPersonRepository = vPersonRepository;
			this.VPersonModelValidator = vPersonModelValidator;
			this.BolVPersonMapper = bolVPersonMapper;
			this.DalVPersonMapper = dalVPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VPersonRepository.All(limit, offset);

			return this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVPersonServerResponseModel> Get(int personId)
		{
			var record = await this.VPersonRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVPersonServerResponseModel>> Create(
			ApiVPersonServerRequestModel model)
		{
			CreateResponse<ApiVPersonServerResponseModel> response = ValidationResponseFactory<ApiVPersonServerResponseModel>.CreateResponse(await this.VPersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolVPersonMapper.MapModelToBO(default(int), model);
				var record = await this.VPersonRepository.Create(this.DalVPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVPersonServerResponseModel>> Update(
			int personId,
			ApiVPersonServerRequestModel model)
		{
			var validationResult = await this.VPersonModelValidator.ValidateUpdateAsync(personId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVPersonMapper.MapModelToBO(personId, model);
				await this.VPersonRepository.Update(this.DalVPersonMapper.MapBOToEF(bo));

				var record = await this.VPersonRepository.Get(personId);

				return ValidationResponseFactory<ApiVPersonServerResponseModel>.UpdateResponse(this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiVPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int personId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VPersonModelValidator.ValidateDeleteAsync(personId));

			if (response.Success)
			{
				await this.VPersonRepository.Delete(personId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e59de247f2dbcf1bcc2e5c9b03814217</Hash>
</Codenesium>*/