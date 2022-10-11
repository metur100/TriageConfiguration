using TriageConfiguration.TriageElements;

namespace TriageConfiguration.TrieageDrawer
{
    public class ConsoleTriageDrawer : ITriageDrawer
    {
        public void StartSet(string? customerName, string? description)
        {
            Console.WriteLine($"Customer name: {customerName} {"\n" + "Description: "} {description} {"\n"}");
        }

        public void StartRuleSet(string? description)
        {
            Console.WriteLine($"Description: {description}");
        }

        public void AddBoolRule(CriteriaEnum? criteria, bool? stateValue)
        {
            Console.WriteLine($" Criteria: {criteria} = {stateValue}");
        }

        public void AddRegExRule(CriteriaEnum? criteria, string? regEx)
        {
            Console.WriteLine($" Criteria: {criteria} = {regEx}");
        }

        public void AddRangeRule(CriteriaEnum? criteria, double? maxRange, double? minRange)
        {
            Console.WriteLine($" Criteria: {criteria} is inbetween {minRange} und {maxRange}");
        }

        public void AddResult(string? name, string? description, bool? repairCostsVisible, bool? residualValueVisible, bool? replacementValueVisible, ActionTypeEnum? actionType)
        {
            Console.WriteLine(
                $"Result: {name} {"\n" + "  Description: "} {description} " +
                $"{"\n" + "  RepairCostsVisible: "} {repairCostsVisible}" +
                $"{"\n" + "  ResidualValueVisible: "} {residualValueVisible}" +
                $"{"\n" + "  ReplacementValueVisible: "} {replacementValueVisible}" +
                $"\n  Action: {actionType}" + "\n");
        }

        public void EndSetResult(string? name, string? description, bool? repairCostsVisible, bool? residualValueVisible, bool? replacementValueVisible)
        {
            Console.WriteLine(
                $"Default Result: {name} {"\n" + "  Description: "} {description}" +
                $"{"\n" + "  RepairCostsVisible: "} {repairCostsVisible}" +
                $"{"\n" + "  ResidualValueVisible: "} {residualValueVisible}" +
                $"{"\n" + "  ReplacementValueVisible: "} {replacementValueVisible}" + "\n");
        }

        public string GetVisualization()
        {
            return "WARNING: No web visualization, it is a console output!";
        }
    }
}
