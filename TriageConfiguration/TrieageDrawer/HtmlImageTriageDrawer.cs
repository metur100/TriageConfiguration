using HandlebarsDotNet;
using System.Text;
using TriageConfiguration.TriageElements;
using TriageConfiguration.UI;

namespace TriageConfiguration.TrieageDrawer
{
    public class HtmlImageTriageDrawer : ITriageDrawer
    {
        private readonly Styles _styles = new();
        private readonly StringBuilder LogString = new();
        private StringBuilder SavedString = new();

        public void StartSet(string? customerName, string? description)
        {
            string htmlStartSet =
                @"<!DOCTYPE html>
                <html>
                <head>";

            string htmlCustomerAndDesc = @"
                   <div align=""center"">
                     <div class=""tittleStyle"">
                        <p>Customer name: {{CustomerName}}</p>
                        <p>Description: {{Description}}</p>
                     </div>";

            var  stylesList = _styles.StyleList.Aggregate((a, b) => a + " " + b);
            var template = Handlebars.Compile(htmlStartSet + stylesList + "</head><body>" + htmlCustomerAndDesc);

            var data = new
            {
                CustomerName = customerName,
                Description = description
            };
            var result = template(data);    
            SavedString = LogString.Append(result).Append(Environment.NewLine);
        }

        public void StartRuleSet(string? description)
        {
            string htmlRuleStartSet =
                @"<div class=""diamond"">
                    <div class=""centerRuleSet"">
                      <h3>{{Description}}</h3>
                  </div>
                  <div class=""centerCriteria"">";

            var template = Handlebars.Compile(htmlRuleStartSet);
            var data = new
            {
                Description = description,
            };
            var result = template(data);
            SavedString = LogString.Append(result).Append(Environment.NewLine);
        }

        public void AddBoolRule(CriteriaEnum? criteria, bool? stateValue)
        {
            string htmlBoolRule =
                @"<div class=""rules"">
                     <p>{{Criteria}} = {{StateValue}}</p>
                </div>";

            var template = Handlebars.Compile(htmlBoolRule);
            var data = new
            {
                StateValue = stateValue,
                Criteria = criteria
            };
            var result = template(data);
            SavedString = LogString.Append(result).Append(Environment.NewLine);
        }

        public void AddRangeRule(CriteriaEnum? criteria, double? maxRange, double? minRange)
        {
            string htmlRangeRule =
                @"<div class=""rules"">
                     <p>{{Criteria}} > {{MinRange}} < {{MaxRange}}</p>
                  </div>";

            var template = Handlebars.Compile(htmlRangeRule);
            var data = new
            {
                Criteria = criteria,
                MaxRange = maxRange,
                MinRange = minRange
            };
            var result = template(data);
            SavedString = LogString.Append(result).Append(Environment.NewLine);
        }

        public void AddRegExRule(CriteriaEnum? criteria, string? regEx)
        {
            string htmlRegExRule =
                @"<div class=""rules"">
                      <p>{{Criteria}} = {{RegEx}}</p>
                  </div>";

            var template = Handlebars.Compile(htmlRegExRule);
            var data = new
            {
                Criteria = criteria,
                RegEx = regEx
            };
            var result = template(data);
            SavedString = LogString.Append(result).Append(Environment.NewLine);
        }

        public void AddResult(string? name, string? description, bool? repairCostsVisible, bool? residualValueVisible, bool? replacementValueVisible, ActionTypeEnum? actionType)
        {
            string htmlResultName =
                @"</div>
                    <div class=""arrowDown"">
                  </div>
                  <div class=""no""><p>NO</p></div>
                  </div>
                    <div class=""arrowRight"">
                    </div>
                    <div class=""yes""><p>YES</p></div>
                    <div class=""rect"">
                        <p>{{Name}}</p>
                    <div class=""resultDescription"">
                        <p>{{Description}}</p>
                    </div>
                    <div class=""resultBools"">
                    <div id=""inputPreview"">";

            var inputRepairCosts = InputOptionsCheckBox("demo_opt_1", "RepairCosts", repairCostsVisible);
            var inputResidualValue = InputOptionsCheckBox("demo_opt_2", "ResidualValue", residualValueVisible);
            var inputReplacementValue = InputOptionsCheckBox("demo_opt_3", "ReplacementValue", replacementValueVisible);

            var actionResult = AddActionResult(actionType);

            var template = Handlebars.Compile(htmlResultName + inputRepairCosts + inputResidualValue + inputReplacementValue + "</div></div>" + actionResult + "</div>");

            var data = new
            {
                Name = name,
                Description = description,
                RepairCostsVisible = repairCostsVisible,
                ResidualValueVisible = residualValueVisible,
                ReplacementValueVisible = replacementValueVisible
            };
            var result = template(data);
            SavedString = LogString.Append(result).Append(Environment.NewLine);
        }

        public void EndSetResult(string? name, string? description, bool? repairCostsVisible, bool? residualValueVisible, bool? replacementValueVisible)
        {
            string htmlResultName =
                @"<div class=""defaultResultTittle"">
                        <h3>Default Result</h3>
                    </div>
                    <div class=""rectDefault"">
                        <p>{{Name}}</p>
                    <div class=""resultDescription"">
                        <p>{{Description}}</p>
                    <div class=""resultDefaultBools"">
                    <div id=""inputPreview"">";

            var inputRepairCosts = InputOptionsCheckBox("demo_opt_1", "RepairCosts", repairCostsVisible);
            var inputResidualValue = InputOptionsCheckBox("demo_opt_2", "ResidualValue", residualValueVisible);
            var inputReplacementValue = InputOptionsCheckBox("demo_opt_3", "ReplacementValue", replacementValueVisible);

            var template = Handlebars.Compile(htmlResultName + inputRepairCosts + inputResidualValue + inputReplacementValue + " </div></div></div></body></html>");
            var data = new
            {
                Name = name,
                Description = description
            };
            var result = template(data);
            SavedString = LogString.Append(result).Append(Environment.NewLine);
        }

        public string GetVisualization()
        {
            if (SavedString.Length > 0)
            {
                return SavedString.ToString();
            }
            return string.Empty;
        }

        public static string CheckBoxValue(bool? isChecked)
        {
            if (isChecked == true)
            {
                return "checked";
            }
            return string.Empty;
        }

        public static string InputOptionsCheckBox(string? option, string? lebel, bool? isChecked)
        {
            string htmlCheckBox = $@"
                   <input name = ""cssCheckbox"" id = ""{option}"" 
                       type = ""checkbox"" class=""css-checkbox""{CheckBoxValue(isChecked)}>
                       <label for= ""demo_opt_1"">{lebel}</label>";

            return htmlCheckBox;
        }

        public static string AddActionResult(ActionTypeEnum? actionType)
        {
            if (actionType == ActionTypeEnum.PerformLineByLineCalculation)
            {
                return $@"<div class=""lineByLine"">
                   <input name = ""cssCheckbox"" id = ""demo_opt_1"" 
                       type = ""checkbox"" class=""css-checkbox""checked>
                       <label for= ""demo_opt_1"">LineByLineCalculation</label></div>";
            }
            return string.Empty;
        }
    }
}
