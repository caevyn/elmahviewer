using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elmah;
using ElmahViewer.Data;

namespace ElmahViewer.Models
{
    public class ErrorViewModelFactory : IErrorListViewModelFactory, IErrorDetailsViewModelFactory
    {
        private readonly IErrorLogFactory _logFactory;
        private readonly IElmahApplicationRepository _repository;

        public ErrorViewModelFactory(IErrorLogFactory logFactory, IElmahApplicationRepository repository)
        {
            _logFactory = logFactory;
            _repository = repository;
        }

        public ErrorListViewModel Create(string id, int index, int size)
        {
            if (index < 0)
            {
                index = 0;
            }
            if(size <= 0)
            {
                size = 10;
            }
            var allApps = _repository.GetAllApplicationNames().ToList();
            var allAppsModel = new ApplicationListModel {Applications = allApps, CurrentApplication = id};

            List<ErrorLogEntry> errors = new List<ErrorLogEntry>(size);
            int count = _logFactory.Create(id).GetErrors(index, size, errors);

            var errorModels = errors.Select(e =>
                                            new ErrorModel
                                            {
                                                Id = e.Id,
                                                HostName = e.Error.HostName,
                                                StatusCode = e.Error.StatusCode,
                                                StatusDescription =
                                                    e.Error.StatusCode > 0
                                                        ? HttpWorkerRequest.GetStatusDescription(e.Error.StatusCode)
                                                        : null,
                                                Type = e.Error.Type,
                                                HumaneType = ErrorDisplay.HumaneExceptionErrorType(e.Error),
                                                Message = e.Error.Message,
                                                User = e.Error.User,
                                                When = FuzzyTime.FormatInEnglish(e.Error.Time),
                                                Iso8601Time = e.Error.Time.ToString("o"),
                                            }).ToList();


            var model = new ErrorListViewModel
                {
                    Count = count,
                    Errors = errorModels,
                    ApplicationName = id,
                    PageIndex = index,
                    PageSize = size,
                    AllApplications = allAppsModel
                };

            return model;
        }

        public ErrorDetailsViewModel Create(string applicationId, string errorId)
        {
            var entry = _logFactory.Create(applicationId).GetError(errorId);
            return new ErrorDetailsViewModel { Id = errorId, Error = entry.Error };
        }
    }
}