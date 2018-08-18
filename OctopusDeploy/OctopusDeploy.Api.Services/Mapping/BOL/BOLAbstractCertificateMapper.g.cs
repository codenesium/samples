using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractCertificateMapper
	{
		public virtual BOCertificate MapModelToBO(
			string id,
			ApiCertificateRequestModel model
			)
		{
			BOCertificate boCertificate = new BOCertificate();
			boCertificate.SetProperties(
				id,
				model.Archived,
				model.Created,
				model.DataVersion,
				model.EnvironmentIds,
				model.JSON,
				model.Name,
				model.NotAfter,
				model.Subject,
				model.TenantIds,
				model.TenantTags,
				model.Thumbprint);
			return boCertificate;
		}

		public virtual ApiCertificateResponseModel MapBOToModel(
			BOCertificate boCertificate)
		{
			var model = new ApiCertificateResponseModel();

			model.SetProperties(boCertificate.Id, boCertificate.Archived, boCertificate.Created, boCertificate.DataVersion, boCertificate.EnvironmentIds, boCertificate.JSON, boCertificate.Name, boCertificate.NotAfter, boCertificate.Subject, boCertificate.TenantIds, boCertificate.TenantTags, boCertificate.Thumbprint);

			return model;
		}

		public virtual List<ApiCertificateResponseModel> MapBOToModel(
			List<BOCertificate> items)
		{
			List<ApiCertificateResponseModel> response = new List<ApiCertificateResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ed1f42f629f725e0841fcb018769cd0f</Hash>
</Codenesium>*/