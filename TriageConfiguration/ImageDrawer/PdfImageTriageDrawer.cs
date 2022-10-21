using ceTe.DynamicPDF.HtmlConverter;
using TriageConfiguration.Drawer;
using TriageConfiguration.TriageElements;

namespace TriageConfiguration.ImageDrawer
{
    public class PdfImageTriageDrawer : ITriageDrawer
    {
        private readonly HtmlImageTriageDrawer _htmlImageDrawer = new();
        public void StartSet(string? customerName, string? description, OutputTypeEnum? outputType)
        {
            _htmlImageDrawer.StartSet(customerName, description, OutputTypeEnum.PdfImage);
        }

        public void StartRuleSet(string? description)
        {
            _htmlImageDrawer.StartRuleSet(description);
        }

        public void AddBoolRule(CriteriaEnum? criteria, bool? stateValue)
        {
            _htmlImageDrawer.AddBoolRule(criteria, stateValue);
        }

        public void AddRangeRule(CriteriaEnum? criteria, double? maxRange, double? minRange)
        {
            _htmlImageDrawer.AddRangeRule(criteria, maxRange, minRange);
        }

        public void AddRegExRule(CriteriaEnum? criteria, string? regEx)
        {
            _htmlImageDrawer.AddRegExRule(criteria, regEx);
        }

        public void AddResult(string? name, string? description, bool? repairCostsVisible, bool? residualValueVisible, bool? replacementValueVisible, ActionTypeEnum? actionType)
        {
            _htmlImageDrawer.AddResult(name, description, repairCostsVisible, residualValueVisible, replacementValueVisible, actionType);
        }

        public void EndSetResult(string? name, string? description, bool? repairCostsVisible, bool? residualValueVisible, bool? replacementValueVisible)
        {
            _htmlImageDrawer.EndSetResult(name, description, repairCostsVisible, residualValueVisible, replacementValueVisible);
        }

        public string GetVisualization()
        {
            var html = _htmlImageDrawer.GetVisualization();
            ConvertHtmlToPdf(html);

            return html;
        }

        public static byte[] ConvertHtmlToPdf(string html)
        {
            ConversionOptions conversionOptions = new (1024, 1024, 0);
            byte[] pdfByteArray = Converter.Convert(html, null, conversionOptions);

            return pdfByteArray;
        }
    }
}
