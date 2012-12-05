using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElmahViewer.Data
{
    public class ElmahApplicationRepository : IElmahApplicationRepository
    {
        public IEnumerable<string> GetAllApplicationNames()
        {
            var result = Massive.DB.Current.Query("Select Distinct [Application] FROM ELMAH_Error");
            var expandos = result.Cast<IDictionary<string, object>>();
            var appNames = expandos.SelectMany(x => x.Values).Cast<string>();
            return appNames;
        }
    }
}