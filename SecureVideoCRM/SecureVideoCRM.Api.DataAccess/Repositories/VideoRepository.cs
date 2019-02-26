using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.DataAccess
{
	public partial class VideoRepository : AbstractVideoRepository, IVideoRepository
	{
		public VideoRepository(
			ILogger<VideoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>56f3d8130d763aba1d684b75ba085c30</Hash>
</Codenesium>*/