using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALClientCommunicationMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOClientCommunication dto,
			ClientCommunication efClientCommunication)
		{
			efClientCommunication.SetProperties(
				id,
				dto.ClientId,
				dto.DateCreated,
				dto.EmployeeId,
				dto.Notes);
		}

		public virtual DTOClientCommunication MapEFToDTO(
			ClientCommunication ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOClientCommunication();

			dto.SetProperties(
				ef.Id,
				ef.ClientId,
				ef.DateCreated,
				ef.EmployeeId,
				ef.Notes);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>e1f22fe2a28c50ee19d573bdb1261f2d</Hash>
</Codenesium>*/