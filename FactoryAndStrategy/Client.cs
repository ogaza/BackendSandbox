using System.Data;
using FactoryAndStrategyPatternExample.Factory;

namespace FactoryAndStrategyPatternExample
{
    public class Client
    {
        public ReportSummary CreateUsReport()
        {
            var dataOrigin = DataOrigin.Us;

            var report = new Report(new DataTable());            

            IReportSummaryGenerator generator = ReportSummaryGeneratorFactory.
                GetReportGenerator(dataOrigin);
            
            return generator.
                GenerateReportSummary(report);
        }
    }
}
