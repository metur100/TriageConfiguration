using Microsoft.AspNetCore.Mvc;
using TriageConfiguration.TriageElements;
using TriageConfiguration.TrieageDrawer;

namespace TriageConfigurationWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisualizerController : Controller
    {
        /// <summary>
        /// Import a new json string.
        /// If successful, string will be converted into html image.
        /// </summary>
        /// <param name="triageConfig">Triage configuration to be visualized</param>
        /// <param name="outputType">Type of the output</param>
        /// <returns></returns>

        [HttpPost("generateVisualizedFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVisualizedFile(TriageConfig? triageConfig, OutputTypeEnum outputType)
        {
            var result = string.Empty;
            var output = string.Empty;
            try
            {
                switch (outputType)
                {
                    case OutputTypeEnum.HtmlImage:
                        result = TriageDrawer.Draw(triageConfig, new HtmlImageTriageDrawer());
                        output = "text/html";
                        break;
                    case OutputTypeEnum.HtmlText:
                        result = TriageDrawer.Draw(triageConfig, new HtmlTextTriageDrawer());
                        output = "text/html";
                        break;
                    case OutputTypeEnum.Text:
                        result = TriageDrawer.Draw(triageConfig, new TextTriageDrawer());
                        output = "text/txt";
                        break;
                    default:
                        break;
                }
                return Content(result, output);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
