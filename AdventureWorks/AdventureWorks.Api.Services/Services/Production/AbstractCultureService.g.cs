using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCultureService : AbstractService
	{
		private IMediator mediator;

		protected ICultureRepository CultureRepository { get; private set; }

		protected IApiCultureServerRequestModelValidator CultureModelValidator { get; private set; }

		protected IDALCultureMapper DalCultureMapper { get; private set; }

		private ILogger logger;

		public AbstractCultureService(
			ILogger logger,
			IMediator mediator,
			ICultureRepository cultureRepository,
			IApiCultureServerRequestModelValidator cultureModelValidator,
			IDALCultureMapper dalCultureMapper)
			: base()
		{
			this.CultureRepository = cultureRepository;
			this.CultureModelValidator = cultureModelValidator;
			this.DalCultureMapper = dalCultureMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCultureServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.CultureRepository.All(limit, offset, query);

			return this.DalCultureMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiCultureServerResponseModel> Get(string cultureID)
		{
			var record = await this.CultureRepository.Get(cultureID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCultureMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCultureServerResponseModel>> Create(
			ApiCultureServerRequestModel model)
		{
			CreateResponse<ApiCultureServerResponseModel> response = ValidationResponseFactory<ApiCultureServerResponseModel>.CreateResponse(await this.CultureModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalCultureMapper.MapModelToBO(default(string), model);
				var record = await this.CultureRepository.Create(bo);

				response.SetRecord(this.DalCultureMapper.MapBOToModel(record));
				await this.mediator.Publish(new CultureCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCultureServerResponseModel>> Update(
			string cultureID,
			ApiCultureServerRequestModel model)
		{
			var validationResult = await this.CultureModelValidator.ValidateUpdateAsync(cultureID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalCultureMapper.MapModelToBO(cultureID, model);
				await this.CultureRepository.Update(bo);

				var record = await this.CultureRepository.Get(cultureID);

				var apiModel = this.DalCultureMapper.MapBOToModel(record);
				await this.mediator.Publish(new CultureUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCultureServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCultureServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CultureModelValidator.ValidateDeleteAsync(cultureID));

			if (response.Success)
			{
				await this.CultureRepository.Delete(cultureID);

				await this.mediator.Publish(new CultureDeletedNotification(cultureID));
			}

			return response;
		}

		public async virtual Task<ApiCultureServerResponseModel> ByName(string name)
		{
			Culture record = await this.CultureRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCultureMapper.MapBOToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>772f978e7d8e44ac86c5698f3758192c</Hash>
</Codenesium>*/