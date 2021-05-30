namespace Dietitian.Reporters
{
    public class ReportManager
    {
        private readonly ReportBuilderBase _builder;

        public ReportManager(ReportBuilderBase builder)
        {
            _builder = builder;
        }

        public string BuildPersonalInfoFirst()
        {
            string content = _builder.BuildHeader();
            content += _builder.BuildPersonalInfo();
            content += _builder.BuildDietInfo();
            content += _builder.BuildFooter();
            return content;
        }
        public string BuildDietInfoFirst()
        {
            string content = _builder.BuildHeader();
            content += _builder.BuildDietInfo();
            content += _builder.BuildPersonalInfo();
            content += _builder.BuildFooter();
            return content;
        }

    }

}
