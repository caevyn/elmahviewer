namespace ElmahViewer.Models
{
    public interface IErrorListViewModelFactory
    {
        ErrorListViewModel Create(string id, int index, int size);
    }
}
