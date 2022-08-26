using Kae.DomainModel.CSharp.Utility.Application.WebAPIAppDomainModelViewer.Controllers;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Kae.DomainModel.CSharp.Utility.Application.WebAPIAppDomainModelViewer
{
    public class WebAPILogger : Kae.Utility.Logging.Logger
    {
        ILogger<DomainModelController> logger;

        public WebAPILogger(ILogger<DomainModelController> logger)
        {
            this.logger = logger;
        }

        protected override Task LogInternal(Level level, string log, string timestamp)
        {
            throw new System.NotImplementedException();
        }
    }
}
