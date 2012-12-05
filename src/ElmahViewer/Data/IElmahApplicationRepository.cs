using System.Collections.Generic;

namespace ElmahViewer.Data
{
    public interface IElmahApplicationRepository
    {
        IEnumerable<string> GetAllApplicationNames();
    }
}
