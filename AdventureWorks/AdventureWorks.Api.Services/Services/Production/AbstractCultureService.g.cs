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

		protected IBOLCultureMapper BolCultureMapper { get; private set; }

		protected IDALCultureMapper DalCultureMapper { get; private set; }

		private ILogger logger;

		public AbstractCultureService(
			ILogger logger,
			IMediator mediator,
			ICultureRepository cultureRepository,
			IApiCultureServerRequestModelValidator cultureModelValidator,
			IBOLCultureMapper bolCultureMapper,
			IDALCultureMapper dalCultureMapper)
			: base()
		{
			this.CultureRepository = cultureRepository;
			this.CultureModelValidator = cultureModelValidator;
			this.BolCultureMapper = bolCultureMapper;
			this.DalCultureMapper = dalCultureMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCultureServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CultureRepository.All(limit, offset);

			return this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(records));
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
				return this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCultureServerResponseModel>> Create(
			ApiCultureServerRequestModel model)
		{
			CreateResponse<ApiCultureServerResponseModel> response = ValidationResponseFactory<ApiCultureServerResponseModel>.CreateResponse(await this.CultureModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCultureMapper.MapModelToBO(default(string), model);
				var record = await this.CultureRepository.Create(this.DalCultureMapper.MapBOToEF(bo));

				var businessObject = this.DalCultureMapper.MapEFToBO(record);
				response.SetRecord(this.BolCultureMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCultureMapper.MapModelToBO(cultureID, model);
				await this.CultureRepository.Update(this.DalCultureMapper.MapBOToEF(bo));

				var record = await this.CultureRepository.Get(cultureID);

				var businessObject = this.DalCultureMapper.MapEFToBO(record);
				var apiModel = this.BolCultureMapper.MapBOToModel(businessObject);
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
				return this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>f732197901ebf92b2ec363ef1d022453</Hash>
</Codenesium>*/