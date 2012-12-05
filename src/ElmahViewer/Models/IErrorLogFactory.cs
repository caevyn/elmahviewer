using Elmah;

namespace ElmahViewer.Models
{
    public interface IErrorLogFactory
    {
        ErrorLog Create(string applicationId);
    }
}
