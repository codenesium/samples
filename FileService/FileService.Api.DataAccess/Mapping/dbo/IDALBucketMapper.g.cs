using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public interface IDALBucketMapper
	{
		void MapDTOToEF(
			int id,
			DTOBucket dto,
			Bucket efBucket);

		DTOBucket MapEFToDTO(
			Bucket efBucket);
	}
}

/*<Codenesium>
    <Hash>f277ceeac01844959902580a26f7388f</Hash>
</Codenesium>*/