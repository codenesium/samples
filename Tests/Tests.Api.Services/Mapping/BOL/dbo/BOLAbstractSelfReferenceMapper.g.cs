using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractSelfReferenceMapper
	{
		public virtual BOSelfReference MapModelToBO(
			int id,
			ApiSelfReferenceServerRequestModel model
			)
		{
			BOSelfReference boSelfReference = new BOSelfReference();
			boSelfReference.SetProperties(
				id,
				model.SelfReferenceId,
				model.SelfReferenceId2);
			return boSelfReference;
		}

		public virtual ApiSelfReferenceServerResponseModel MapBOToModel(
			BOSelfReference boSelfReference)
		{
			var model = new ApiSelfReferenceServerResponseModel();

			model.SetProperties(boSelfReference.Id, boSelfReference.SelfReferenceId, boSelfReference.SelfReferenceId2);

			return model;
		}

		public virtual List<ApiSelfReferenceServerResponseModel> MapBOToModel(
			List<BOSelfReference> items)
		{
			List<ApiSelfReferenceServerResponseModel> response = new List<ApiSelfReferenceServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c105f209b83545fe1975ab981e41c1b2</Hash>
</Codenesium>*/