namespace ElmahViewer.Models
{
    public interface IErrorDetailsViewModelFactory
    {
        ErrorDetailsViewModel Create(string applicationId, string errorId);
    }
}