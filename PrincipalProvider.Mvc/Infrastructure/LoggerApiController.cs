using System.Web.Http;
using Castle.Core.Logging;

namespace PrincipalProvider.Mvc.Infrastructure
{
	public abstract class LoggerApiController : ApiController
	{
		private ILogger _logger = NullLogger.Instance;

		/// <summary>
		/// Logger implementation.
		/// </summary>
		public ILogger Logger
		{
			get { return _logger; }
			set { _logger = value; }
		}
	}
}
