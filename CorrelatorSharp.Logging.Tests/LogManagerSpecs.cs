using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorrelatorSharp.Logging.NLog;
using Machine.Specifications;

namespace CorrelatorSharp.Logging.Tests
{
    [Subject(typeof(LogManager))]
    public class LogManagerSpecs
    {
        private static ILogger _logger; 

        Establish context = () =>
        {
            LoggingConfiguration.LogManager = new LogManagerAdaptor();  
        };

        Because of = () => _logger = LogManager.GetCurrentClassLogger();

        It should_have_caling_class_name_as_logger = () => _logger.Name.ShouldEqual("CorrelatorSharp.Logging.Tests.LogManagerSpecs+<>c");
    }
}
